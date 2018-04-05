using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentskiDom.Data.EF;
using StudentskiDom.Data.Models;
using StudentskiDom.Web.ViewModel;

namespace StudentskiDom.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
       

		private readonly MojContext _db;

		public AutentifikacijaController(MojContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			return View(new LoginVM()
			{
				ZapamtiPassword = true,
			});
		}

		public IActionResult Login(LoginVM input)
		{
			KorisnickiNalog korisnik = _db.KorisnickiNalozi
				.SingleOrDefault(x => x.KorisnickoIme == input.username && x.Lozinka == input.password);

			if (korisnik == null)
			{
				TempData["error_poruka"] = "pogrešan username ili password";
				return View("Index", input);
			}

			//HttpContext.SetLogiraniKorisnik(korisnik, input.ZapamtiPassword);

			return RedirectToAction("Index", "Home");
		}

		public IActionResult Logout()
		{

			return RedirectToAction("Index");
		}
	}
}