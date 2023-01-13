using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
	public class SiteSettingViewModel
	{
		[Display(Name = "نام")]
		[Required(ErrorMessage ="نباید بدون مقدار باشد")]
		[MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد.")]
		public string Name { get; set; }

		[Display(Name = "توضیحات")]
		[DataType(DataType.MultilineText)]
		public string Desc { get; set; }

		[Display(Name = "تلفن")]
		[Required(ErrorMessage ="نباید بدون مقدار باشد")]
		[MaxLength(40, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد.")]
		public string Tel { get; set; }

		[Display(Name = "شماره فکس")]
		[MaxLength(40, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد.")]
		public string Fax { get; set; }
	}
}
