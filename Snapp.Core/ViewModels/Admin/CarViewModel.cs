using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.Admin
{
	public class CarViewModel
	{
		[Display(Name = "نام خودرو")]
		[Required(ErrorMessage = "نباید بدون مقدار باشد")]
		[MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد.")]
		public string Name { get; set; }
	}
}
