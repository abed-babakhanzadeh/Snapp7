using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;

namespace Snapp7.Controllers
{
    public class MonthTypeController : Controller
    {
        private IAdmin _admin;

        public MonthTypeController(IAdmin admin)
        {
            _admin = admin;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetMonthTypes();
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
                _admin.AddMonthType(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await _admin.GetMonthTypesById(id);
            MonthTypeViewModel viewModel = new MonthTypeViewModel()
            {
                End = result.End,
                Name= result.Name,
                Percent = result.Percent,
                Start = result.Start
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, MonthTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _admin.UpdateMonthType(id, viewModel);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeleteMonthType(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
