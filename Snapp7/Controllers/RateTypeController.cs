using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;

namespace Snapp7.Controllers
{
	public class RateTypeController : Controller
	{
		private IAdmin _admin;

		public RateTypeController(IAdmin admin)
		{
			_admin= admin;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _admin.GetRateTypes();
			return View(result);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(RateTypeViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_admin.AddRateType(viewModel);
				return RedirectToAction(nameof(Index));
			}
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var result = await _admin.GetRateTypesById(id);
			RateTypeViewModel viewModel = new RateTypeViewModel()
			{
				Name = result.Name,
				Ok= result.Ok,
				ViewOrder = result.ViewOrder,
			};
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Edit(Guid id, RateTypeViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				bool result = _admin.UpdateRateType(id, viewModel);
				if (result)
				{
					return RedirectToAction(nameof(Index));
				}
				
			}
			return View(viewModel);
		}

		public IActionResult Delete(Guid id)
		{
			_admin.DeleteRateType(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
