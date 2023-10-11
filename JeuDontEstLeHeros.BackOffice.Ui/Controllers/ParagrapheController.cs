using JeuDontEstLeHeros.Core.Application.DTO;
using JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit;
using JeuDontEstLeHeros.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace JeuDontEstLeHeros.BackOffice.Ui.Controllers
{
    public class ParagrapheController : Controller
    {
        private readonly IParagrapheWorkOfUnit _workOfUnit;
        private readonly IQuestionWorkOfUnit _questionWorkOfUnit;

        public List<SelectListItem> Questions = new ();

        public ParagrapheController(IParagrapheWorkOfUnit workOfUnit, IQuestionWorkOfUnit questionWorkOfUnit)
        {
            _workOfUnit = workOfUnit;
            _questionWorkOfUnit = questionWorkOfUnit;
        }

        #region Action controller

        [HttpGet]
        public IActionResult Index()
        {
            List<Paragraphe> paragraphes = _workOfUnit.Entities.GatAll().ToList();
            return View(paragraphes);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            IActionResult result = BadRequest();
            try
            {
                Paragraphe? paragraphe = _workOfUnit.Entities.GetParagrapheById(Id);
                if (paragraphe is not null)
                {
                    result = this.View(paragraphe);
                }
                else result = this.RedirectToAction(nameof(Index));
            }
            catch
            {
                result = this.Problem("Probleme avec la requête.");
            }
            
            return result;
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            IActionResult result = BadRequest();
            try
            {
                AddQuestion();
                Paragraphe? paragraphe = _workOfUnit.Entities.GetParagrapheById(Id);
                if (paragraphe is not null)
                {
                    result = this.View(paragraphe);
                }
                else result = this.RedirectToAction(nameof(Index));
            }
            catch
            {
                result = this.Problem("Probleme avec la requête.");
            }

            return result;
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddQuestion();
            return View();
        }

        /// <summary>
        /// action qui va creer un paragraphe dans la base de données
        /// </summary>
        /// <param name="paragraphe"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromForm]ParagrapheDTO paragraphe )
        {
            IActionResult result = BadRequest();
            try
            {
                if (paragraphe is not null && this.ModelState.IsValid) {

                    _workOfUnit.Entities.Add(new Paragraphe()
                    {
                        Numero = paragraphe.Numero,
                        Titre = paragraphe.Titre,
                        Description = paragraphe.Description,
                        QuestionId = paragraphe.QuestionId
                    });
                    _workOfUnit.Save();
                    result = this.RedirectToAction(nameof(Index));
                
                } else
                {
                    AddQuestion();
                    result = View(paragraphe);   // retourne suir la même page
                }

            }
            catch
            {
                result = this.Problem("Probleme au niveau de l'enregistrement du paragraphe");
            }

            return result;
        }

        [HttpPost]
        public IActionResult Edits([FromForm] Paragraphe paragraphe)
        {
            IActionResult result = this.BadRequest();

            try
            {
                if (paragraphe is not null && paragraphe.Id > 0 && this.ModelState.IsValid)
                {
                    _workOfUnit.Entities.Update(paragraphe);
                    _workOfUnit.Save();
                    result = this.RedirectToAction(nameof(Index));
                }
                else
                {
                    AddQuestion();
                    result = View(paragraphe);
                }
                
            } catch
            {
                result = this.Problem("Erreur lors de la sauvegarde du paragraphe.");
            }

            return result;
        }

        #endregion


        #region méthode private 
        /// <summary>
        /// méthode qui construit le select des questions
        /// </summary>
        private void AddQuestion()
        {
            Questions.Clear();
            Questions.AddRange(_questionWorkOfUnit.Entities.GetAll().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Titre,
            }));

            this.ViewBag.Questions = Questions;

        }
        #endregion
    }
}
