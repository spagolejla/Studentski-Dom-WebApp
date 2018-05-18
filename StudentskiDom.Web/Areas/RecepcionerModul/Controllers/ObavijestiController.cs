using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentskiDom.Data.EF;
using StudentskiDom.Data.Models;
using StudentskiDom.Web.Areas.RecepcionerModul.ViewModels;

namespace StudentskiDom.Web.Areas.RecepcionerModul.Controllers
{
	[Area("RecepcionerModul")]
	public class ObavijestiController : Controller
    {
		MojContext _context;

		public ObavijestiController(MojContext db)
		{
			_context = db;
		}
		public IActionResult Index()
        {
			ObavijestiIndexVM model = new ObavijestiIndexVM
			{
				Rows = _context.Obavijesti.Select(x => new ObavijestiIndexVM.Row
				{
					id=x.Id,
					Datum=x.Datum,
					Sadrzaj=x.Sadrzaj,
					Naslov=x.Naslov,
					Procitana=x.procitana,
					zaSve=x.zaSve,
					zaZaposlenike=x.samoZaposlenicima,
					PostavioZaposlenik=x._Zaposlenik.Ime+" "+x._Zaposlenik.Prezime
				}).ToList()
			};
				
				


			
            return PartialView("Index",model);
        }

		public IActionResult Dodaj()
		{

			ObavijestiDodajVM model = new ObavijestiDodajVM
			{
				Datum = DateTime.Now,
				Zaposlenici = _context.Zaposlenici.Select(x => new SelectListItem
				{
					Value = x.Id.ToString(),
					Text = x.Ime + " " + x.Prezime

				}).ToList()
			};




			return View("Dodaj",model);
		}

		public IActionResult Snimi(ObavijestiDodajVM model)
		{
			if (!ModelState.IsValid)
			{
				model.Datum = DateTime.Now;
				model.Zaposlenici = _context.Zaposlenici.Select(x => new SelectListItem
				{
					Value = x.Id.ToString(),
					Text = x.Ime + " " + x.Prezime

				}).ToList();
				
			}
			Obavijesti novaObavijest = new Obavijesti
			{
				Datum = model.Datum,
				Sadrzaj = model.Sadrzaj,
				Naslov = model.Naslov,
				_ZaposlenikId = model.ZaposlenikID,
				zaSve =model.zaSve, 
				samoZaposlenicima =!model.zaSve,
				procitana=false
			};

			_context.Obavijesti.Add(novaObavijest);
			_context.SaveChanges();


			return Redirect("/RecepcionerModul/Home/Index");
		}

		public IActionResult Obrisi(int id)
		{

			Obavijesti ob = _context.Obavijesti.Where(x => x.Id == id).FirstOrDefault();
			_context.Obavijesti.Remove(ob);
			_context.SaveChanges();




			return Redirect("/RecepcionerModul/Home/Index");
		}
	}
}