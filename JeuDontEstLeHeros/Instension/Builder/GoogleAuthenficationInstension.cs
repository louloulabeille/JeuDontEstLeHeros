using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace JeuDontEstLeHeros.Instension.Builder
{
    public static class GoogleAuthenficationInstension
    {
        /// <summary>
        /// méthode ajout de service pour l'authentification de google
        /// </summary>
        /// <param name="services">IserviceCollection</param>
        /// <param name="configuration">builder.configuration</param>
        /// <returns>retourne le service</returns>
        /// <exception cref="NullReferenceException">si les données client id et secret id de API sont manquant</exception>
        public static IServiceCollection AddAuthenficationGoogleInstension(this IServiceCollection services, ConfigurationManager configuration)
        {
            string idClient = configuration["Authentication:Google:ClientId"] ?? throw new NullReferenceException();
            string clientSecret = configuration["Authentication:Google:ClientSecret"] ?? throw new NullReferenceException();

            services.AddAuthentication().AddGoogle(googleOptions => {
                googleOptions.ClientId = idClient;
                googleOptions.ClientSecret = clientSecret;
            });

            return services;
        }
    }
}
