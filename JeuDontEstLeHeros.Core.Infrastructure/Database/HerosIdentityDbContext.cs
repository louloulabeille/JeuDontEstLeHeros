using JeuDontEstLeHeros.Core.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JeuDontEstLeHeros.Core.Infrastructure.Database;

public class HerosIdentityDbContext : IdentityDbContext<HerosIdentityUser>
{
    public HerosIdentityDbContext(DbContextOptions<HerosIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
