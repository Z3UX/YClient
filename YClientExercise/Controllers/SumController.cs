using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YClientExercise.Data;
using YClientExercise.Models;
using System.Threading.Tasks;

namespace YClientExercise.Controllers
{
    [ApiController]
    [Route("v1/sum")]
    public class SumController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<double> Post(
            [FromServices] DataContext context,
            [FromBody] List<int> numberIds)
        {
            string queryString = "SELECT * FROM numbers WHERE id = ";

            double sum = 0;

            if (numberIds.Count == 1)
            {
                queryString = queryString + numberIds[0] + ";";

            }
            else
            {
                for (int i = 0; i < numberIds.Count - 1; i++)
                {
                    queryString = queryString + numberIds[i] + " OR id = ";
                }

                queryString = queryString + numberIds[numberIds.Count - 1] + ";";
            }

            var queryRaw = context.Numbers.FromSqlRaw(queryString);

            var queryResult = await queryRaw.ToListAsync();

            foreach (Number number in queryResult)
            {
                sum += number.Value;
            }

            return sum;
        }
    }
}