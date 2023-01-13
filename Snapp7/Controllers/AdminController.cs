using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;
using Snapp.DataAccessLayer.Entities;

namespace Snapp7.Controllers
{
	public class AdminController : Controller
	{
		private IAdmin _admin;

		public AdminController(IAdmin admin)
		{
			_admin= admin;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> SiteSetting()
		{
			Setting setting = await _admin.GetSetting();
			SiteSettingViewModel viewModel = new SiteSettingViewModel()
			{
				Desc = setting.Desc,
				Fax= setting.Fax,
				Name= setting.Name,
				Tel = setting.Tel
			};

			ViewBag.IsSuccess = false;
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult SiteSetting(SiteSettingViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				bool result = _admin.UpdateSiteSetting(viewModel);
			
				ViewBag.IsSuccess = result;
			}
			return View(viewModel);
		}


		[HttpGet]
		public async Task<IActionResult> PriceSetting()
		{
			Setting setting = await _admin.GetSetting();
			PriceSettingViewModel viewModel = new PriceSettingViewModel()
			{
				IsDistance = setting.IsDistance,
				IsWeatherPrice = setting.IsWeatherPrice,
			};

			ViewBag.IsSuccess = false;
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult PriceSetting(PriceSettingViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				bool result = _admin.UpdatePriceSetting(viewModel);
			
				ViewBag.IsSuccess = result;
			}
			return View(viewModel);
		}


		[HttpGet]
		public async Task<IActionResult> AboutSetting()
		{
			Setting setting = await _admin.GetSetting();
			AboutSettingViewModel viewModel = new AboutSettingViewModel()
			{
				About = setting.About,
			};

			ViewBag.IsSuccess = false;
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult AboutSetting(AboutSettingViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				bool result = _admin.UpdateAboutSetting(viewModel);
			
				ViewBag.IsSuccess = result;
			}
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> TermsSetting()
		{
			Setting setting = await _admin.GetSetting();
			TermsSettingViewModel viewModel = new TermsSettingViewModel()
			{
				Terms = setting.Terms,
			};

			ViewBag.IsSuccess = false;
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult TermsSetting(TermsSettingViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				bool result = _admin.UpdateTermsSetting(viewModel);
			
				ViewBag.IsSuccess = result;
			}
			return View(viewModel);
		}
	}
}
