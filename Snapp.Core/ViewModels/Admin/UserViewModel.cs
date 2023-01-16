using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Snapp.Core.ViewModels.Admin
{
    public class UserViewModel
    {
        [Display(Name = "نقش کاربر")]
        public Guid RoleId { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(11, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد.")]
        [MinLength(11, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد.")]
        [Phone(ErrorMessage = "شماره همراه معتبر وارد نمایید")]
        public string Username { get; set; }

        [Display(Name = "فعال/غیر فعال")]
        public bool IsActive { get; set; }
    }
}
