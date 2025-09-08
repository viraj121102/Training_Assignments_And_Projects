using Microsoft.EntityFrameworkCore;
//using MVCExample.Models;
using Models;

namespace MVCExample.Data
{
    public class EcomContext : DbContext
    {
        // creating constructor
        public EcomContext(DbContextOptions<EcomContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
