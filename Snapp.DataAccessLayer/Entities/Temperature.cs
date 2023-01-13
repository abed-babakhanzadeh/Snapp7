﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.DataAccessLayer.Entities
{
	public class Temperature
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid Id { get; set; }

		[Display(Name = "عنوان")]
		[MaxLength(100)]
		public string Name { get; set; }

		[Display(Name = "از دما")]
		public int Start { get; set; }

		[Display(Name = "تا دما")]
		public int End { get; set; }

		[Display(Name = "درصد")]
		public float Percent { get; set; }
	}
}
