using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels
{
	public class RegisterViewModel
	{
		[Display(Name = "شماره همراه")]
		[Required(ErrorMessage = "لطفا یک شماره همراه معتبر وارد نمایید")]
		[MaxLength(11, ErrorMessage = "لطفا یک شماره همراه معتبر وارد نمایید")]
		[MinLength(11, ErrorMessage = "لطفا یک شماره همراه معتبر وارد نمایید")]
		[Phone(ErrorMessage = "لطفا یک شماره همراه معتبر وارد نمایید")]
		public string Username { get; set; }
	}
}
