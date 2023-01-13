using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;

namespace Snapp7.Controllers
{
	public class TemperatureController : Controller
	{
		private IAdmin _admin;

		public TemperatureController(IAdmin admin)
		{
			_admin= admin;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _admin.GetTemperatures();
			return View(result);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(MonthTypeViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_admin.AddTemperature(viewModel);
				return RedirectToAction(nameof(Index));
			}
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var result = await _admin.GetTemperaturesById(id);
			MonthTypeViewModel viewModel= new MonthTypeViewModel()
			{
				End = result.End,
				Name= result.Name,
				Percent= result.Percent,
				Start = result.Start
			};
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Edit(Guid id, MonthTypeViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var result = _admin.UpdateTemperature(id, viewModel);
				if (result)
				{
					return RedirectToAction(nameof(Index));
				}
			}
			return View(viewModel);
		}

		public IActionResult Delete(Guid id)
		{
			_admin.DeleteTemperature(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
