using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;

namespace Snapp7.Controllers
{
	public class CarController : Controller
	{
		private IAdmin _admin;

		public CarController(IAdmin admin)
		{
			_admin= admin;
		}
		
		public async Task<IActionResult> Index()
		{
			var result = await _admin.GetCars();
			return View(result);
		}

		[HttpGet]
        public IActionResult Create()
        {
			return View();
        }

        [HttpPost]
        public IActionResult Create(CarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
				_admin.AddCar(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

		[HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
			var result = await _admin.GetCarById(id);
			CarViewModel viewModel = new CarViewModel()
            {
				Name= result.Name
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, CarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateCar(id, viewModel);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(viewModel);

        }

        public IActionResult Delete(Guid id)
        {
             _admin.DeleteCar(id);
            //if (result)
            //{
            //    return RedirectToAction(nameof(Index));
            //}

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ImportFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if(file != null)
            {
				using (var stream = new MemoryStream())
				{
					await file.CopyToAsync(stream);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(stream))
					{
						ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
						var rowCount = worksheet.Dimension.Rows;

						for (int i = 2; i <= rowCount; i++)
						{
							CarViewModel viewModel = new CarViewModel()
							{
								Name = worksheet.Cells[i, 1].Value.ToString().Trim()
							};
							_admin.AddCar(viewModel);
						}
					}
				}
				return RedirectToAction(nameof(Index));
			}
            else
            {
                //ModelState.TryAddModelError("Name", "فایلی انتخاب نشده است");
                return RedirectToAction(nameof(ImportFile));
            }
            
        }
	}
}
