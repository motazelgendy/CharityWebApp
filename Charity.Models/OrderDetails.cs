﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Models
{
	public class OrderDetails
	{
		public int Id { get; set; }
		[Required]
		public int OrderId { get; set; }
		[ForeignKey("OrderId")]
		public OrderHeader OrderHeader { get; set; }

		[Required]
		public int ProgramItemId { get; set; }
		[ForeignKey("ProgramItemId")]
		public virtual ProgramItem ProgramItem { get; set; }

		public int Count { get; set; }
		[Required]
		public double Price { get; set; }
		public string Name { get; set; }

	}
}
