using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFDataApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataApp.Controllers
{
	public class HomeController : Controller
	{
		private OrderUserContext db;
		public HomeController(OrderUserContext context)
		{
			db = context;
		}
		public async Task<IActionResult> Index(SortState sortOrder = SortState.UserIdAsc)
		{
			IQueryable<Order> orders = db.Orders.Include(x => x.User);

			ViewData["UserIdSort"] = sortOrder == SortState.UserIdAsc ? SortState.UserIdDesc : SortState.UserIdAsc;
			ViewData["DescSort"] = sortOrder == SortState.DescriptionAsc ? SortState.DescriptionDesc : SortState.DescriptionAsc;
			ViewData["OdateSort"] = sortOrder == SortState.OdateAsc ? SortState.OdateDesc : SortState.OdateAsc;
			ViewData["CountSort"] = sortOrder == SortState.CntAsc ? SortState.CntDesc : SortState.CntAsc;
			ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
			ViewData["BdateSort"] = sortOrder == SortState.BdateAsc ? SortState.BdateDesc : SortState.BdateAsc;
			ViewData["ScoreSort"] = sortOrder == SortState.ScoreAsc ? SortState.ScoreDesc : SortState.ScoreAsc;

			switch(sortOrder)
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
			return View(await orders.AsNoTracking().ToListAsync());
		}
		
	}
}
