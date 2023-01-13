using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels;
using Snapp.DataAccessLayer.Entities;

namespace Snapp7.Controllers
{
	public class AccountController : Controller
	{
		private IAccount _account;

		public AccountController(IAccount account)
		{
				_account = account;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				User user = await _account.RegisterUser(viewModel);
				if (user != null)
				{
					return RedirectToAction(nameof(Active));
				}
			}
			return View(viewModel);
		}


        [HttpGet]
        public IActionResult Driver()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Driver(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _account.RegisterDriver(viewModel);
                if (user != null)
                {
                    return RedirectToAction(nameof(Active));
                }
            }
            return View(viewModel);
        }


		[HttpGet]
		public IActionResult Active()
		{
			ViewBag.IsError = false;
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Active(ActiveViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				User user = await _account.ActiveUser(viewModel);
				if (user != null)
				{
                    ViewBag.IsError = false;
                    return View(viewModel);
                    //احراز هویت و ورود به داشبورد
                }
			}
			ViewBag.IsError = true;
			return View(viewModel);
		}
	}
}
