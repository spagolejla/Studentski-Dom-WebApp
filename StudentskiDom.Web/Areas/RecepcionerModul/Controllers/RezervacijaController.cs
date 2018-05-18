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
	public class RezervacijaController : Controller
    {

		MojContext _context;

		public RezervacijaController(MojContext db)
		{
			_context = db;
		}
		public IActionResult Index()
        {
			RezervacijeIndexVM model = new RezervacijeIndexVM
			{
				Rows = _context.RezervacijeSale.Select(x=>new RezervacijeIndexVM.Row {
					Id=x.Id,
					Datum=x.Datum,
					BrojSati=x.BrojSati,
					UkupnaCijena=x.BrojSati*x._Sala.CijenaPoSatu,
					sala=x._Sala.Naziv,
					zaposlenik=x._Zaposlenik.Ime+" "+x._Zaposlenik.Prezime,
					posjetilac=x._Posjetilac.Ime+" "+x._Posjetilac.Prezime

				}).ToList()
			};
            return View("Index",model);
        }



		public IActionResult SaleDetalji()
		{
			SaleDetaljiVM model = new SaleDetaljiVM
			{
				Rows = _context.Sale.Select(x => new SaleDetaljiVM.Row
				{
					Id=x.Id,
					Kapacitet=x.Kapacitet,
					CijenaPoSatu=x.CijenaPoSatu,
					Naziv=x.Naziv
				}).ToList()
			};
			return View("SaleDetalji",model);
		}

		public IActionResult DodajPosjetioca() {
			PosjetilacDodajVM model = new PosjetilacDodajVM();

			return View("DodajPosjetioca",model);
		}

		public IActionResult SnimiDodajPosjetioca()
		{
			return View("DodajPosjetioca");
		}


	}
}