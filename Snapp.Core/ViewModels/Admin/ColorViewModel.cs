using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
	public class ColorViewModel
	{
		[Display(Name = "نام رنگ")]
		[Required(ErrorMessage ="نباید بدون مقدار باشد")]
		[MaxLength(20, ErrorMessage ="مقدار {0} نباید بیشتر از {1} باشد.")]
		public string Name { get; set; }

        [Display(Name = "کد رنگ")]
		[Required(ErrorMessage ="نباید بدون مقدار باشد")]
		[MaxLength(10, ErrorMessage ="مقدار {0} نباید بیشتر از {1} باشد.")]
		public string Code { get; set; }
	}
}
