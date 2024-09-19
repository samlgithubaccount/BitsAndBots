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

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var client = new IdentityRole("client");
            client.NormalizedName = "client";

            var seller = new IdentityRole("seller");
            seller.NormalizedName = "seller";

            modelBuilder.Entity<IdentityRole>().HasData(admin, client, seller);

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
