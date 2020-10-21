using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YClientExercise.Data;
using YClientExercise.Models;

namespace YClientExercise.Controllers
{
    [ApiController]
    [Route("v1/numbers")]
    public class NumberController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Number>> Post(
            [FromServices] DataContext context,
            [FromBody] Number model)
        {
            if (ModelState.IsValid)
            {
                context.Numbers.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}