using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.Admin
{
	public class PriceTypeViewModel
	{
		[Display(Name = "عنوان تعرفه")]
		[Required(ErrorMessage = "نباید بدون مقدار باشد")]
		[MaxLength(50, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد.")]
		public string Name { get; set; }

		[Display(Name = "از مسافت")]
		public int Start { get; set; }

		[Display(Name = "تا مسافت")]
		public int End { get; set; }

		[Display(Name = "نرخ ثابت")]
		public long Price { get; set; }
	}
}
