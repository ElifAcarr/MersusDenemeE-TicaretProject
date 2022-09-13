using Mersus.ETicaret.Models;
using Microsoft.EntityFrameworkCore;

namespace Mersus.ETicaret.Database
{
    public class ETicaretContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Box> Boxs { get; set; }
        public ETicaretContext(DbContextOptions<ETicaretContext> options) : base(options)
        {

        }

       /* protected override void OnModelCreating(ModelBuilder builder)
        {   
            base.OnModelCreating(builder);
        }*/
    }
}
