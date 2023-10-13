using JeuDontEstLeHeros.Core.Infrastructure.Database;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace JeuDontEstLeHeros.UI.Instension.Builder
{
    public static class DbContextInstension
    {
        public static void AddDbContextInstension(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Heros") ?? throw new NullReferenceException();

            services.AddDbContext<HerosDbcontext>(options =>
            {
                options.UseSqlServer(connectionString);
            },ServiceLifetime.Scoped);
        }
    }
}
