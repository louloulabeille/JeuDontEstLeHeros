using JeuDontEstLeHeros.Core.Application.WorkOfUnit;
using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit;
using JeuDontEstLeHeros.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JeuDontEstLeHeros.BackOffice.Ui.Controllers
{
    [Authorize]
    public class ReponseController : Controller
    {
        private readonly IReponseWorkOfUnit _workOfUnit;

        [BindProperty]
        public Reponse? Reponse { get; set; }

        //public ReponseController (HerosDbcontext dbcontext)
        public ReponseController(IReponseWorkOfUnit workOfUnit )
        {
            //_workOfUnit = new ReponseWorkOfUnit(dbcontext);
            _workOfUnit = workOfUnit;
            Reponse = new Reponse() { Id = 0 };
            this.ModelState.Clear();
        }

        public IActionResult Index()
        {
            List<Reponse> list = _workOfUnit.Reponses.ReponseByDesc(11).ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Reponse reponse)
        {
            IActionResult result = this.BadRequest();
            try
            {
                if (reponse != null && this.ModelState.IsValid)
                {
                    _workOfUnit.Reponses.Add(reponse);
                    _workOfUnit.Save();
                    result = this.RedirectToAction(nameof(Index));
                    this.ModelState.Clear();
                }
                else result = this.View(reponse);
            }
            catch
            {
                result = this.Problem("Probleme au niveau de l'enregistrement de la réponse");
            }

            return result;
        }

        [HttpGet]
        public IActionResult Create()
        {
            Reponse reponse = new();
            return View(reponse);
        }
    }
}
