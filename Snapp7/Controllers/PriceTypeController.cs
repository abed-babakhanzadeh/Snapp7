using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;
using Snapp.DataAccessLayer.Entities;

namespace Snapp7.Controllers
{
	public class PriceTypeController : Controller
	{
		private IAdmin _admin;

		public PriceTypeController(IAdmin admin)
		{
			_admin= admin;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _admin.GetPriceTypes();

			return View(result);
		}

        [HttpGet]
        public IActionResult Create()
        {
			return View();
        }

		[HttpPost]
        public IActionResult Create(Guid id, PriceTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddPriceType(viewModel);
				return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _admin.GetPriceTypesById(id);
            PriceTypeViewModel viewModel = new PriceTypeViewModel()
            {
                Name = result.Name,
                Start = result.Start,
                End= result.End,
                Price = result.Price,
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, PriceTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdatePriceType(id, viewModel);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeletePriceType(id);
            return RedirectToAction(nameof(Index));
        }
	}
}
