namespace JeuDontEstLeHeros.Instension.App
{
    public static class GestionRouteAppInstensions
    {
        /// <summary>
        /// méthode d'instension pour l'ajout des routes dans l'application
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication? AddMapControllerRouteInstensions(this WebApplication? app)
        {
            if (app is not null )
            {
                #region Controller Aventure
                app.MapControllerRoute(
                    name: "mesaventures",
                    pattern: "mes-aventures",
                    defaults: new { controller = "Aventure", action = "Index" }
                );

                app.MapControllerRoute(
                    name: "demarrerNouvelleAventure",
                    pattern: "demarrer-nouvelle-aventure",
                    defaults: new {controller = "Aventure", action = "Create"}
                );

                app.MapControllerRoute(
                    name: "afficheaventure",
                    pattern: "affiche-aventure/{id?}",
                    defaults: new { controller = "Aventure", action = "Details" }
                );
                #endregion

                #region Route par défaut
                // map route par défaut 2 facons de faire
                app.MapDefaultControllerRoute();
                /*app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");*/
                #endregion
            }

            return app;
        }
    }
}
