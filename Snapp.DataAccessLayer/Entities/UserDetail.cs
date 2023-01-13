using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Snapp.DataAccessLayer.Entities
{
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Display(Name = "تاریخ عضویت")]
        [MaxLength(10)]
        public string Date { get; set; }

        [Display(Name = "ساعت عضویت")]
        [MaxLength(10)]
        public string Time { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(100)]
        [MaybeNull]
        public string FullName { get; set; }

        [Display(Name = "تاریخ تولد")]
        [MaxLength(10)]
        [MaybeNull]
        public string BirthDate { get; set; }

        public virtual User User { get; set; }
    }
}
