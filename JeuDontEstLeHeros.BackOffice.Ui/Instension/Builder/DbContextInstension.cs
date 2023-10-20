using JeuDontEstLeHeros.Core.Infrastructure.Database;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace JeuDontEstLeHeros.BackOffice.Ui.Instension.Builder
{
    public static class DbContextInstension
    {
        public static IServiceCollection AddDbContextInstension(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Heros") ?? throw new NullReferenceException();
            string connectionStringIdentity = configuration["ConnectionStrings:IdentityHeros"] ?? throw new NullReferenceException();
            services.AddDbContext<HerosDbcontext>(options =>
            {
                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Scoped);

            services.AddDbContext<HerosIdentityDbContext>(options=>
            {
                options.UseSqlServer(connectionStringIdentity);
            }, ServiceLifetime.Scoped);

            return services;
        }
    }
}
