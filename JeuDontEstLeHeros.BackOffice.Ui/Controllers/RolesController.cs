using JeuDontEstLeHeros.Core.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JeuDontEstLeHeros.BackOffice.Ui.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RolesController> _logger;

        [BindProperty]
        public RolesDTO? Role {  get; set; } = new RolesDTO();

        public RolesController(RoleManager<IdentityRole> roleManager, ILogger<RolesController> logger)
        {
            _roleManager = roleManager;
            _logger = logger;
        }

        // GET: RolesController
        /// <summary>
        /// affiche la liste des roles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var result = _roleManager.Roles.Select(x => new RolesDTO()
            {
                Id = x.Id,
                Name = x.Name?? string.Empty,
                NormalizedName = x.NormalizedName,
                ConcurrencyStamp = x.ConcurrencyStamp,
            });
            return View(result);
        }

        // GET: RolesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View(Role);
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] RolesDTO roles)
        {
            ActionResult result = this.View(roles);
            try
            {
                if (this.ModelState.IsValid && !string.IsNullOrEmpty(roles.Name))
                {
                    if (!await _roleManager.RoleExistsAsync(roles.Name))
                    {
                        await _roleManager.CreateAsync(new IdentityRole()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = roles.Name,
                            NormalizedName = roles.NormalizedName,
                            ConcurrencyStamp = roles.ConcurrencyStamp,
                        });
                        result = this.RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        this.ModelState.AddModelError("Name", "Role déjà existant. Veuillez changer le nom.");
                        result = this.View(roles);
                    }
                }
                else
                {
                    result = this.View(roles);
                }
            }
            catch
            {
                result = this.NotFound();
            }
            return result;
        }

        // GET: RolesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
