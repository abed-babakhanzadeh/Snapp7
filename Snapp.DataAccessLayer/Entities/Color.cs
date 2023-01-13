using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snapp.DataAccessLayer.Entities
{
    public class Color
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }


        [Display(Name = "نام رنگ")]
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Display(Name = "کد رنگ")]
        [MaxLength(10)]
        public string Code { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
