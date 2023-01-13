using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;

namespace Snapp7.Controllers
{
	public class HumidityController : Controller
	{
		private IAdmin _admin;

		public HumidityController(IAdmin admin)
		{
			_admin= admin;
		}

		public async Task<IActionResult> Index()
		{
			var result =await _admin.GetHumidities();
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
				_admin.AddHumidity(viewModel);
				return RedirectToAction(nameof(Index));
			}
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var result = await _admin.GetHumiditiesById(id);
			MonthTypeViewModel viewModel= new MonthTypeViewModel()
			{
				End = result.End,
				Start= result.Start,
				Name= result.Name,
				Percent = result.Percent
			};
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Edit(Guid id, MonthTypeViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var result = _admin.UpdateHumidity(id, viewModel);
				if (result)
				{
					return RedirectToAction(nameof(Index));
				}
			}
			return View(viewModel);
		}

		public IActionResult Delete(Guid id)
		{
			_admin.DeleteHumidity(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
