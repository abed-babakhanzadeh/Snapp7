using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Snapp.DataAccessLayer.Entities
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("User")]
        public Guid UserId { get; set; }


        
        [MaybeNull]
        [AllowNull]
        public Guid? CarId { get; set; }


        [MaybeNull]
        [AllowNull]
        public Guid? ColorId { get; set; }


        [Display(Name = "کد ملی")]
        [MaxLength(10)]
        [MaybeNull]
        public string NationalCode { get; set; }

        [Display(Name = "تلفن ثابت")]
        [MaxLength(30)]
        [MaybeNull]
        public string Tel { get; set; }

        [Display(Name = "آدرس")]
        [MaybeNull]
        public string Address { get; set; }

        [Display(Name = "شماره پلاک")]
        [MaxLength(30)]
        [MaybeNull]
        public string CarCode { get; set; }

        [Display(Name = "تصویر گواهینامه")]
        [MaybeNull]
        public string Img { get; set; }

        [Display(Name = "تصویر راننده")]
        [MaybeNull]
        public string Avatar { get; set; }

        [Display(Name = "تایید")]
        public bool IsConfirm { get; set; }


        public virtual User User { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
    }
}
