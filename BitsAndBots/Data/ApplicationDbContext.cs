using BitsAndBots.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BitsAndBots.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole, String>(options)
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
