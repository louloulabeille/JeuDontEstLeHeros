using JeuDontEstLeHeros.Core.Application.Repository;
using JeuDontEstLeHeros.Core.Application.WorkOfUnit;
using JeuDontEstLeHeros.Core.Infrastructure.DataLayer;
using JeuDontEstLeHeros.Core.Interfaces.Layout;
using JeuDontEstLeHeros.Core.Interfaces.Repository;
using JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit;
using JeuDontEstLeHeros.Core.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace JeuDontEstLeHeros.BackOffice.Ui.Instension.Builder
{
    public static class InjectionRepositoryDataLayerInstension
    {
        /// <summary>
        /// instension de méthode pour l'injection de dépendance des classes
        /// d'accès aux données
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepoDataScopedInstension(this IServiceCollection services)
        {
            services.AddScoped<IReponseDataLayer,ReponseDataLayer>();
            services.AddScoped<IReponseRepository,ReponseRepository>();
            services.AddScoped<IReponseWorkOfUnit, ReponseWorkOfUnit>();

            services.AddScoped<IParagrapheDataLayer, ParagrapheDataLayer>();
            services.AddScoped<IParagrapheRepository, ParagrapheRepository>();
            services.AddScoped<IParagrapheWorkOfUnit, ParagrapheWorkOfUnit>();

            services.AddScoped<IQuestionDataLayer, QuestionDataLayer>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionWorkOfUnit, QuestionWorkOfUnit>();
        }
    }
}
