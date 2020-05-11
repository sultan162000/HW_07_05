using Microsoft.EntityFrameworkCore;


namespace DZ_07_05.Models
{
    class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuild)
        {
            optionBuild.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=test11;Trusted_Connection=True;");
        }
    }
}
