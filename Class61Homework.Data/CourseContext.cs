using Microsoft.EntityFrameworkCore;

namespace Class61Homework.Data
{
    public class CourseContext : DbContext
    {
        private string _connectionString;

        public CourseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
