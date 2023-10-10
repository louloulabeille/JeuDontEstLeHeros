using JeuDontEstLeHeros.Core.Application.DTO;
using JeuDontEstLeHeros.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JeuDontEstLeHeros.UI.Controllers
{
    public class AventureController : Controller
    {
        #region Propriété
        private readonly ILogger<AventureController> _logger;
        private readonly AventureDTO aventure = new ();
        #endregion


        #region Constructeur
        public AventureController(ILogger<AventureController> logger)
        {
            _logger = logger;
        }
        #endregion


        #region Action

        /// <summary>
        /// action d'affichage des aventures
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.MonTitre = "Aventures";

            List<AventureDTO> list = new ()
            {
                new AventureDTO(){Nom = "L'attaque des titans", Id= 1 , Description = "Des titans attaquent les capitales du monde entier."},
                new AventureDTO(){Nom = "L'espoir", Id= 2 , Description = "Après la défaite des nains, l'espoir renait après la naissance du nouveau héros."}
            };


            return View(list);
        }


        /// <summary>
        /// action de creation d'une nouvelle aventure
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create() {
            var result = View();

            return result;
        }

        /// <summary>
        /// action d'enregistrement du formulaire
        /// </summary>
        /// <param name="aventure"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create ( [FromForm] AventureDTO aventure)
        {
            var result = BadRequest();

            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
