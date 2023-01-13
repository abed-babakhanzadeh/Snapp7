using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels
{
	public class ActiveViewModel
	{
		[Display(Name = "کد فعالسازی")]
		[Required(ErrorMessage = "لطفا کد 6 رقمی معتبر وارد کنید")]
		[MaxLength(6, ErrorMessage = "لطفا کد 6 رقمی معتبر وارد کنید")]
		[MinLength(6, ErrorMessage = "لطفا کد 6 رقمی معتبر وارد کنید")]
		[Phone(ErrorMessage = "لطفا کد 6 رقمی معتبر وارد کنید")]
		public string Code { get; set; }
	}
}
