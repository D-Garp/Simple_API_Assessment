using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Applicant> applicant { get; set; }
        public DbSet<Skill> skills { get; set; }
       
    }
}
