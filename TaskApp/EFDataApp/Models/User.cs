using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString ="{0:dd'.'MM'.'yyyy}",ApplyFormatInEditMode =true)]
		[Display(Name="Дата регистрации")]
		public DateTime Bdate { get; set; }
		public int Score { get; set; }	
		public List<Order> Orders { get; set; }
		public User()
		{
			Orders = new List<Order>();
		}
	}
}
