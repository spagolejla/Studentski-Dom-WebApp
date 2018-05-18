using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentskiDom.Data.EF;
using StudentskiDom.Web.Areas.RecepcionerModul.ViewModels;

namespace StudentskiDom.Web.Areas.RecepcionerModul.Controllers
{
	[Area("RecepcionerModul")]
	public class SobeController : Controller
    {

		MojContext _context;

		public SobeController(MojContext db)
		{
			_context = db;
		}
		public IActionResult Index()
        {
			SobeIndexVM model = new SobeIndexVM {
				Rows = _context.Sobe.Select(x => new SobeIndexVM.Row {
					Id = x.Id,
					Naziv = x.Naziv,
					Sprat = x.Sprat,
					TipSobe = x._TipSobe.Naziv,
					PopunjenoKreveta = x.BrojKreveta,
				    lista=_context.StudentiSobe.Where(r=>r._SobaId==x.Id).ToList()
					

				}).ToList()


		};
			


			return View(model);
        }
    }
}