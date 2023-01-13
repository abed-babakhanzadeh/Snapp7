using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Admin
{
	public class TermsSettingViewModel
	{
		[Display(Name = "شرایط و قوانین استفاده")]
		[DataType(DataType.MultilineText)]
		public string Terms { get; set; }
	}
}
