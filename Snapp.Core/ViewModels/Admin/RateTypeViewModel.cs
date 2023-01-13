using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.Admin
{
	public class RateTypeViewModel
	{
		[Display(Name = "گزینه امتیاز")]
		[Required(ErrorMessage ="نباید بدون مقدار باشد")]
		[MaxLength(40, ErrorMessage ="مقدار {0} نباید بیشتر از {1} باشد.")]
		public string Name { get; set; }

		[Display(Name = "مثبت")]
		public bool Ok { get; set; }

		[Display(Name = "ترتیب نمایش")]
		public int ViewOrder { get; set; }
	}
}

