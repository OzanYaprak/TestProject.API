using Microsoft.EntityFrameworkCore;
using TestProject.API.Models;

namespace TestProject.API.Data
{
    public class TestProjectDBContext : DbContext
    {
        public TestProjectDBContext(DbContextOptions options) : base(options) { }


        public DbSet<Product> Products { get; set; }

    }
}
