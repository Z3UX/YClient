using Microsoft.EntityFrameworkCore;
using YClientExercise.Models;

namespace YClientExercise.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Number> Numbers { get; set; }
    }
}