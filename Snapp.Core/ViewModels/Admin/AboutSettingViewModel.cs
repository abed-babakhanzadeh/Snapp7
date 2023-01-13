using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.Admin
{
	public class AboutSettingViewModel
	{
		[Display(Name = "درباره ما")]
		[DataType(DataType.MultilineText)]
		public string About { get; set; }
	}
}
