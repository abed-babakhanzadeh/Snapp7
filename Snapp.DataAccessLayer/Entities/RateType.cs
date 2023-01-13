using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snapp.DataAccessLayer.Entities
{
	public class RateType
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid id { get; set; }

		[Display(Name = "گزینه ارتباط")]
		[MaxLength(40)]
		public string Name { get; set; }

		[Display(Name = "مثبت")]
		public bool Ok { get; set; }

		[Display(Name = "ترتیب نمایش")]
		public int ViewOrder { get; set; }
	}
}
