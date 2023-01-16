using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;


namespace Snapp7.Controllers
{
    public class RoleController : Controller
    {
        private IAdmin _admin;

        public RoleController(IAdmin admin)
        {
            _admin = admin;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _admin.GetRoles();
            return View(results);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                this._admin.AddRole(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _admin.GetRolesById(id);
            RoleViewModel viewModel = new RoleViewModel()
            {
                Title = result.Title,
                Name = result.Name,
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateRole(id, viewModel);
                if (result)
                {

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(viewModel);

        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeleteRole(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
