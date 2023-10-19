using JeuDontEstLeHeros.Core.Infrastructure.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace JeuDontEstLeHeros.Instension.Builder
{
    public static class DbContextInstension
    {
        public static void AddDbContextInstension(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Heros") ?? throw new NullReferenceException();
            string connectionIdentity = configuration.GetConnectionString("IdentityHeros") ?? throw new NullReferenceException();
            
            services.AddDbContext<HerosDbcontext>(options =>
            {
                options.UseSqlServer(connectionString);
            },ServiceLifetime.Scoped);

            services.AddDbContext<HerosIdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionIdentity);
            });

        }
    }
}
