using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentskiDom.Data.EF;

namespace StudentskiDom.Web.Areas.RecepcionerModul.Controllers
{
	[Area("RecepcionerModul")]
	public class HomeController : Controller
    {

		private readonly MojContext _context;

		public HomeController(MojContext db)
		{
			_context = db;
		}

		public IActionResult Index()
        {
            return View();
        }
    }
}