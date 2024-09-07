using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BitsAndBots.Models;

namespace BitsAndBots.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    { 
        public DbSet<BitsAndBots.Models.Product> Product { get; set; } = default!;
    }
}
