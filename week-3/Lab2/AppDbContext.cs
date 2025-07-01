using lab2;
using Microsoft.EntityFrameworkCore;

namespace lab2
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Change DB name as needed
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RetailStoreDb;Trusted_Connection=True;");
        }
    }
}
