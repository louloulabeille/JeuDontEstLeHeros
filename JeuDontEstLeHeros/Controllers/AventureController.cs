using JeuDontEstLeHeros.Core.Application.DTO;
using JeuDontEstLeHeros.Core.Application.WorkOfUnit;
using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit;
using JeuDontEstLeHeros.Core.Models;
using JeuDontEstLeHeros.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JeuDontEstLeHeros.UI.Controllers
{
    [Authorize]
    public class AventureController : Controller
    {
        #region Propriété
        //private readonly ILogger<AventureController> _logger;
        private readonly IAventureWorkOfUnit _aventureWorkOfUnit;

        [BindProperty]
        public AventureDTO Aventure { get; set; } = new();

        #endregion


        #region Constructeur
        public AventureController(IAventureWorkOfUnit aventureWorkOfUnit)
        {
            //_logger = logger;
            _aventureWorkOfUnit = aventureWorkOfUnit;
        }
        #endregion

        #region 
        /// <summary>
        /// action d'affichage des aventures
        /// il est possible de passer AventureWorkOfUnit au niveau de l'action mais il faut le passé avec l'option [FromServices] sinon
        /// il n'arrive pas à faire l'injection
        /// </summary>
        /// <returns></returns>

        // public IActionResult Index()
        //[HttpGet("mes-aventures")]
        public IActionResult Index([FromServices] IAventureWorkOfUnit aventureWorkOfUnit)
        {
            ViewBag.MonTitre = "Aventures";
            IActionResult result = this.BadRequest();
            try
            {
                //List<AventureDTO> aventures =  _aventureWorkOfUnit.Aventures.GetAll().Select(x=> new AventureDTO()
                List<AventureDTO> aventures = aventureWorkOfUnit.Aventures.GetAll().Select(x => new AventureDTO()
                {
                    Id = x.Id,
                    Nom = x.Nom,
                    Description = x.Description,
                    DateCreation = x.DateCreation,
                }).ToList();

                _aventureWorkOfUnit.Save();
                result = this.View(aventures);

            }catch
            {
                result = this.Problem("Problème au niveau de la récupération des données.");
            }

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
                    _aventureWorkOfUnit.Aventures.Add(new Aventure()
                    {
                        Id= aventure.Id,
                        Nom = aventure.Nom,
                        Description = aventure.Description??string.Empty,
                        DateCreation = aventure.DateCreation,
                    });
                    _aventureWorkOfUnit.Save();
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

        /// <summary>
        /// Affichage de l'enregistrement Aventage
        /// </summary>
        /// <param name="Id">clé primaire</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Details(int? Id) { 
            IActionResult result = this.BadRequest();
            try
            {
                if (Id is not null && Id > 0)
                {
                    Aventure? aventure = _aventureWorkOfUnit.Aventures.GetAventureById(Id.Value);
                    result = aventure is not null?this.View(new AventureDTO()
                    {
                        Id = aventure.Id,
                        Nom = aventure.Nom,
                        Description = aventure.Description,
                        DateCreation = aventure.DateCreation,
                    })
                    :this.RedirectToAction(nameof(Index)); // aventure is null -- redirection vers la liste
                }
                else result = this.RedirectToAction(nameof(Index));
            }
            catch
            {
                result = this.Problem("Erreur lors de la remonté des données.");
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
