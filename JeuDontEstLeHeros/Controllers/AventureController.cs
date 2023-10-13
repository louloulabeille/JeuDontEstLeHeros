using JeuDontEstLeHeros.Core.Application.DTO;
using JeuDontEstLeHeros.Core.Application.WorkOfUnit;
using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit;
using JeuDontEstLeHeros.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JeuDontEstLeHeros.UI.Controllers
{
    public class AventureController : Controller
    {
        #region Propriété
        //private readonly ILogger<AventureController> _logger;
        private readonly IAventureWorkOfUnit _avantureWorkOfUnit;

        [BindProperty]
        public AventureDTO Aventure { get; set; } = new();

        #endregion


        #region Constructeur
        public AventureController(IAventureWorkOfUnit avantureWorkOfUnit)
        {
            //_logger = logger;
            _avantureWorkOfUnit = avantureWorkOfUnit;
        }
        #endregion

        #region 
        /// <summary>
        /// action d'affichage des aventures
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.MonTitre = "Aventures";
            IActionResult result = this.BadRequest();
            try
            {
                List<AventureDTO> aventures =  _avantureWorkOfUnit.Aventures.GetAll().Select(x=> new AventureDTO()
                {
                    Id = x.Id,
                    Nom = x.Nom,
                    Description = x.Description,
                    DateCreation = x.DateCreation,
                }).ToList();

                _avantureWorkOfUnit.Save();
                result = this.View(aventures);

            }catch
            {
                result = this.Problem("Problème au niveau de la récupération des données.");
            }
/*
            List<AventureDTO> list = new ()
            {
                new AventureDTO(){Nom = "L'attaque des titans", Id= 1 , Description = "Des titans attaquent les capitales du monde entier."},
                new AventureDTO(){Nom = "L'espoir", Id= 2 , Description = "Après la défaite des nains, l'espoir renait après la naissance du nouveau héros."}
            };
*/

            return result;
        }


        /// <summary>
        /// action de creation d'une nouvelle aventure
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create() {
            var result = View(Aventure);

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
            IActionResult result = BadRequest();
            try
            {
                if (aventure != null && this.ModelState.IsValid)
                {
                    _avantureWorkOfUnit.Aventures.Add(new Core.Models.Aventure()
                    {
                        Id= aventure.Id,
                        Nom = aventure.Nom,
                        Description = aventure.Description??string.Empty,
                        DateCreation = aventure.DateCreation,
                    });
                    _avantureWorkOfUnit.Save();
                    result = this.RedirectToAction(nameof(Index));
                }
                else result = this.View(aventure);
            }
            catch
            {
                result = this.Problem("Problème au niveau de l'enregistrement d'une aventure");
            }

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
