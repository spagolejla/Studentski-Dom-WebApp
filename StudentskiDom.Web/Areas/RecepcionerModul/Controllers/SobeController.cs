using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentskiDom.Data.EF;
using StudentskiDom.Data.Models;
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
			SobeIndexVM model = new SobeIndexVM
			{
				Rows = _context.Sobe.Select(x => new SobeIndexVM.Row
				{
					Id = x.Id,
					Naziv = x.Naziv,
					Sprat = x.Sprat,
					TipSobe = x._TipSobe.Naziv,
					PopunjenoKreveta = x.BrojKreveta,
					Lista = _context.StudentiSobe.Where(r => r._SobaId == x.Id).Select(s => new StudentSoba
					{
						Id = s.Id,
						_Student = s._Student,
						_StudentId = s._StudentId,
						_SobaId = s._SobaId,
						DatumDodjele = s.DatumDodjele,
						_ZaposlenikId = s._ZaposlenikId,
						Napomena = s.Napomena


					}).ToList()
				}).ToList()
				
			};





			






			return View(model);
        }
    }
}