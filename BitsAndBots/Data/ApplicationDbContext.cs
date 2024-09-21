using BitsAndBots.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BitsAndBots.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole, String>(options)
    {
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Event> Event { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(static entity =>
            {
                entity.HasKey(product => product.Id);
                entity.HasOne(product => product.CreatedUser)
                    .WithMany(user => user.Products)
                    .HasForeignKey(product => product.CreatedUserId)
                    .IsRequired();

                entity.HasMany(product => product.Images)
                    .WithOne(image => image.Product)
                    .HasForeignKey(image => image.ProductId);

                entity.Property(product => product.Tags)
                    .HasConversion(
                        v => string.Join(",", v),
                        v => v.Split(',', StringSplitOptions.None)
                    );
            });

            modelBuilder.Entity<Event>(static entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.CreatedUser)
                    .WithMany(user => user.Events)
                    .HasForeignKey(e => e.CreatedUserId)
                    .IsRequired();

                entity.HasMany(e => e.Images)
                    .WithOne(image => image.Event)
                    .HasForeignKey(image => image.EventId);

                entity.Property(e => e.Tags)
                    .HasConversion(
                        v => string.Join(",", v),
                        v => v.Split(',', StringSplitOptions.None)
                    );
            });
        }
    }
}
