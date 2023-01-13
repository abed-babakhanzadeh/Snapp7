using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;

namespace Snapp7.Controllers
{
	public class ColorController : Controller
	{
		private IAdmin _admin;
		public ColorController(IAdmin admin)
		{
			_admin= admin;
		}

		public async Task<IActionResult> Index()
		{
			var result =await _admin.GetColors();
			return View(result);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(ColorViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_admin.AddColor(viewModel);
				return RedirectToAction(nameof(Index));
			}
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var result = await _admin.GetColorsById(id);
			ColorViewModel viewModel = new ColorViewModel()
			{
				Code= result.Code,
				Name= result.Name,
			};
			return View(viewModel);
		}


		[HttpPost]
		public IActionResult Edit(Guid id, ColorViewModel viewModel)
		{

			if (ModelState.IsValid)
			{
				var result = _admin.UpdateColor(id, viewModel);
				if (result == true)
				{
					return RedirectToAction(nameof(Index));
				}
			}
			return View(viewModel);
		}

		public IActionResult Delete(Guid id)
		{
			_admin.DeleteColor(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
