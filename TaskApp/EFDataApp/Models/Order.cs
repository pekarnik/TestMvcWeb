using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Models
{
	public class Order
	{
		[Key]
		public int UserId { get; set; }
		public string Desc { get; set; }
		[Key]
		public DateTime Odate { get; set; }
		public int Cnt { get; set; }
		public User User { get; set; }
	}
}
