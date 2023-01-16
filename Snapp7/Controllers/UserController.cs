using Microsoft.AspNetCore.Mvc;

namespace Snapp7.Controllers
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    using Snapp.Core.Interfaces;
    using Snapp.Core.ViewModels.Admin;

    public class UserController : Controller
    {
        private IAdmin _admin;

        public UserController(IAdmin admin)
        {
            _admin=admin;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetUsers();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.RoleList = new SelectList(await _admin.GetRoles(), "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddUser(viewModel);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.RoleList = new SelectList(await _admin.GetRoles(), "Id", "Title", viewModel.RoleId);
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
