using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFDataApp.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EFDataApp.Controllers
{
	public class HomeController : Controller
	{
		private OrderUserContext db;
		public HomeController(OrderUserContext context)
		{
			db = context;
		}
		public async Task<IActionResult> Index(int? user,string name,
		DateTime regdate, int? score,
			string desc, DateTime orderdate, int? cnt,int page=1,SortState sortOrder = SortState.UserIdAsc)
		{
			IQueryable<Order> orders = db.Orders.Include(x => x.User);
			if(user!=null)
			{
				orders = orders.Where(p => p.User.Id==user);
			}
			if(!String.IsNullOrEmpty(name))
			{
				orders = orders.Where(p => p.User.Name.Contains(name));
			}
			if(regdate!=null&&regdate>DateTime.Now.AddYears(-100))
			{
				orders = orders.Where(p => p.User.Bdate.Equals(regdate));
			}
			if (score!=null)
			{
				orders = orders.Where(p => p.User.Score == score);
			}
			if (!String.IsNullOrEmpty(desc))
			{
				orders = orders.Where(p => p.Desc.Contains(desc));
			}
			if (orderdate != null&&orderdate > DateTime.Now.AddYears(-100))
			{
				orders = orders.Where(p => p.Odate.Equals(orderdate));
			}
			if (cnt!=null)
			{
				orders = orders.Where(p => p.Cnt == cnt);
			}

			switch (sortOrder)
			{
				case SortState.UserIdDesc:
					orders=orders.OrderByDescending(s => s.UserId);
					break;
				case SortState.DescriptionAsc:
					orders = orders.OrderBy(s => s.Desc);
					break;
				case SortState.DescriptionDesc:
					orders = orders.OrderByDescending(s => s.Desc);
					break;
				case SortState.OdateAsc:
					orders = orders.OrderBy(s => s.Odate);
					break;
				case SortState.OdateDesc:
					orders = orders.OrderByDescending(s => s.Odate);
					break;
				case SortState.CntAsc:
					orders = orders.OrderBy(s => s.Cnt);
					break;
				case SortState.CntDesc:
					orders = orders.OrderByDescending(s => s.Cnt);
					break;
				case SortState.NameAsc:
					orders = orders.OrderBy(s => s.User.Name);
					break;
				case SortState.NameDesc:
					orders = orders.OrderByDescending(s => s.User.Name);
					break;
				case SortState.BdateAsc:
					orders = orders.OrderBy(s => s.User.Bdate);
					break;
				case SortState.BdateDesc:
					orders = orders.OrderByDescending(s => s.User.Bdate);
					break;
				case SortState.ScoreAsc:
					orders = orders.OrderBy(s => s.User.Score);
					break;
				case SortState.ScoreDesc:
					orders = orders.OrderByDescending(s => s.User.Score);
					break;
				default:
					orders = orders.OrderBy(s => s.UserId);
					break;
			}
			var items = await orders.ToListAsync();

			IndexViewModel viewModel = new IndexViewModel
			{
				SortViewModel = new SortViewModel(sortOrder),
				FilterViewModel = new FilterViewModel( user, name, regdate, score, desc, orderdate, cnt),
				Orders = items
			};
			return View(viewModel);
		}
		
	}
}
