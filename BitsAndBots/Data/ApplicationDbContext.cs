using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BitsAndBots.Models;

namespace BitsAndBots.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    { 
        public DbSet<BitsAndBots.Models.Product> Product { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(product => product.Id);
                entity.HasOne(product => product.CreatedUser)
                    .WithMany(user => user.Products)
                    .HasForeignKey(product => product.CreatedUserId)
                    .IsRequired();

                entity.HasMany(product => product.Images)
                    .WithOne(image => image.Product)
                    .HasForeignKey(image => image.ProductId);
            });
        }
    }
}
