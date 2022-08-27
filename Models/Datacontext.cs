
using Microsoft.EntityFrameworkCore;

namespace ProductManager.Models
{
    public class datacontext : DbContext
    {
        public datacontext(DbContextOptions<datacontext> options) : base(options) { }
         public DbSet<Product> Product { get; set; }
         protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasOne(p=>p.Categories)
                .WithMany(c=>c.Product)
                .HasForeignKey(p=>p.CategoriesId);
                
            base.OnModelCreating(builder);
            
        }
    }
}