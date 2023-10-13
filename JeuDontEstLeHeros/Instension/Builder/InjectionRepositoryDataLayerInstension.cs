using JeuDontEstLeHeros.Core.Application.Repository;
using JeuDontEstLeHeros.Core.Application.WorkOfUnit;
using JeuDontEstLeHeros.Core.Infrastructure.DataLayer;
using JeuDontEstLeHeros.Core.Interfaces.Layout;
using JeuDontEstLeHeros.Core.Interfaces.Repository;
using JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit;

namespace JeuDontEstLeHeros.UI.Instension.Builder
{ 
    /// <summary>
    /// class qui appel la méthode d'intension pour les accès aux données de la partie Front de l'application
    /// </summary>
    public static class InjectionRepositoryDataLayerInstension
    {
        public static IServiceCollection AddRepoDataScopedInstension(this IServiceCollection services)
        {
            services.AddScoped<IParagrapheWorkOfUnit,ParagrapheWorkOfUnit>();
            services.AddScoped<IParagrapheRepository, ParagrapheRepository>();
            services.AddScoped<IParagrapheDataLayer, ParagrapheDataLayer>();

            services.AddScoped<IAventureWorkOfUnit, AventureWorkOfUnit>();
            services.AddScoped<IAventureRepository, AventureRepository>();
            services.AddScoped<IAventureDataLayer, AventureDataLayer>();

            return services;
        }
    }
}
