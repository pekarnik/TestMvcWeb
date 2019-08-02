using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Models
{
	public class FilterViewModel
	{
		public FilterViewModel(int? user, string name, DateTime? regdate, int? score,
			string desc, DateTime orderdate, int? count)
		{			
			SelectedUser = user;
			SelectedName = name;
			RegDate = regdate;
			Score = score;
			Desc = desc;
			Orderdate = orderdate;
			Count = count;
		}

		
		public int? SelectedUser { get; private set; }
		public string SelectedName { get; private set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? RegDate { get; private set; }
		public int? Score { get; private set; }
		public string Desc { get; private set; }
		public DateTime Orderdate { get; private set; }
		public int? Count { get; private set; }
	}
}
