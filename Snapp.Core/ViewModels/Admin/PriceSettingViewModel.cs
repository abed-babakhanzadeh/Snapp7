using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
	public class PriceSettingViewModel
	{
		[Display(Name = "محاسبه آب و هوا در قیمت")]
		public bool IsWeatherPrice { get; set; }

		[Display(Name = "محاسبه بعد مسافت در قیمت")]
		public bool IsDistance { get; set; }
	}
}
