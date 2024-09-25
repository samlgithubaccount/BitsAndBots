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
        public DbSet<Fundraiser> Fundraiser { get; set; } = default!;
        public DbSet<IndividualFundraiserParticipationRegistration> IndividualFundraiserParticipationRegistration { get; set; } = default!;
        public DbSet<TeamFundraiserParticipationRegistration> TeamFundraiserParticipationRegistration { get; set; } = default!;

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

            modelBuilder.Entity<Fundraiser>(static entity =>
            {
                entity.HasKey(fundraiser => fundraiser.Id);
                entity.HasOne(fundraiser => fundraiser.CreatedUser)
                    .WithMany(user => user.Fundraisers)
                    .HasForeignKey(fundraiser => fundraiser.CreatedUserId)
                    .IsRequired();

                entity.HasMany(fundraiser => fundraiser.Images)
                    .WithOne(image => image.Fundraiser)
                    .HasForeignKey(image => image.FundraiserId);

                entity.Property(e => e.Tags)
                    .HasConversion(
                        v => string.Join(",", v),
                        v => v.Split(',', StringSplitOptions.None)
                    );
            });

            modelBuilder.Entity<IndividualFundraiserParticipationRegistration>(static entity =>
            {
                entity.HasKey(registration => registration.Id);
                entity.HasOne(registration => registration.User)
                    .WithMany(user => user.IndividualFundraiserRegistrations)
                    .HasForeignKey(registration => registration.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(registration => registration.Fundraiser)
                    .WithMany(fundraiser => fundraiser.IndividualFundraiserRegistrations)
                    .HasForeignKey(registration => registration.FundraiserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TeamFundraiserParticipationRegistration>(static entity =>
            {
                entity.HasKey(registration => registration.Id);
                entity.HasOne(registration => registration.User)
                    .WithMany(user => user.TeamFundraiserRegistrations)
                    .HasForeignKey(registration => registration.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(registration => registration.TeamMembers)
                    .WithMany(user => user.FundraiserRegistrationTeamMemberships);

                entity.HasOne(registration => registration.Fundraiser)
                    .WithMany(fundraiser => fundraiser.TeamFundraiserRegistrations)
                    .HasForeignKey(registration => registration.FundraiserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
