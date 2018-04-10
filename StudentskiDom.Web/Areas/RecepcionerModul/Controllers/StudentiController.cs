using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using StudentskiDom.Data.EF;
using StudentskiDom.Data.Models;
using StudentskiDom.Web.Areas.RecepcionerModul.ViewModels;

namespace StudentskiDom.Web.Areas.RecepcionerModul.Controllers
{
	[Area("RecepcionerModul")]
	public class StudentiController : Controller
    {
		MojContext _context;

		public StudentiController(MojContext db)
		{
			_context = db;
		}
        public IActionResult Index()
        {
			StudentiIndexVM model = new StudentiIndexVM
			{
				Rows = _context.Studenti.Select(x => new StudentiIndexVM.Row
				{
					Id = x.Id,
					Ime = x.Ime,
					Prezime = x.Prezime,
					Spol = x.Spol,
					Jmbg = x.JMBG,
					Grad = x._Grad.Naziv,
					Email = x.Mail,
					Soba_ = _context.StudentiSobe.Where(s => s._StudentId == x.Id).FirstOrDefault()._Soba.Naziv
				}).ToList()
			};
            return View("Index",model);
        }

		public IActionResult Dodaj()
		{
			StudentiDodajVM model = new StudentiDodajVM
			{

				Gradovi = _context.Gradovi.Select(x => new SelectListItem
				{
					Value = x.Id.ToString(),
					Text = x.Naziv

				}).ToList(),

				Fakulteti = _context.Fakulteti.Select(x => new SelectListItem
				{
					Value = x.Id.ToString(),
					Text = x.Naziv

				}).ToList(),

				
				SlobodneSobe = _context.Sobe.Where(x=>x.BrojKreveta<3).Select(x => new SelectListItem
				{
					Value = x.Id.ToString(),
					Text = x.Naziv + x._TipSobe.Naziv

				}).ToList()

			};
			SelectListItem n = new SelectListItem {
				Value = null,
				Text = "Nije odabrano"
			};

			model.SlobodneSobe.Add(n);
			model.Fakulteti.Add(n);
			model.Gradovi.Add(n);

			return View("Dodaj",model);
		}

		public IActionResult Snimi(StudentiDodajVM model)
		{
			if (!ModelState.IsValid)
			{
				model.Gradovi = _context.Gradovi.Select(x => new SelectListItem
				{
					Value = x.Id.ToString(),
					Text = x.Naziv

				}).ToList();

				model.Fakulteti = _context.Fakulteti.Select(x => new SelectListItem
				{
					Value = x.Id.ToString(),
					Text = x.Naziv

				}).ToList();

				model.SlobodneSobe = _context.Sobe.Where(x => x.BrojKreveta <= 3).Select(x => new SelectListItem
				{
					Value = x.Id.ToString(),
					Text = x.Naziv + x._TipSobe.Naziv

				}).ToList();

				SelectListItem n = new SelectListItem
				{
					Value = null,
					Text = "Nije odabrano"
				};

				model.SlobodneSobe.Add(n);
				model.Fakulteti.Add(n);
				model.Gradovi.Add(n);

				return View("Dodaj", model);
			}

			Student noviStudent = new Student()
			{
				Ime=model.Ime,
				Prezime=model.Prezime,
				Spol=model.Spol,
				JMBG=model.Jmbg,
				Mail=model.Email,
				Adresa=model.Adresa,
				DatumRodjenja=(DateTime)model.DatumRodjenja,
				Telefon=model.Telefon,
				_GradId=model.GradId,
				_FakultetId=model.FakultetId

			};
			_context.Studenti.Add(noviStudent);
			_context.SaveChanges();

			if (model.SlobodnaSobaId != null)
			{
				StudentSoba noviStudentSoba = new StudentSoba();
				noviStudentSoba.DatumDodjele = DateTime.Now;
				noviStudentSoba._StudentId = noviStudent.Id;
				noviStudentSoba._SobaId = (int)model.SlobodnaSobaId;
				noviStudentSoba._AkademskaGodinaId = 18; //staviti na null ako budemo update database!!!
				noviStudentSoba._ZaposlenikId = 1;  //moram ovako jer nije dozvoljeno null, promjeniti kad budemo autentifikaicju
				_context.StudentiSobe.Add(noviStudentSoba);
				_context.SaveChanges();
			

			Soba izabranaSoba= _context.Sobe.Where(x => x.Id == model.SlobodnaSobaId).FirstOrDefault();
			izabranaSoba.BrojKreveta++;
			_context.Sobe.Update(izabranaSoba);
			_context.SaveChanges();
			}

			KorisnickiNalog noviNalog = new KorisnickiNalog();
			noviNalog.KorisnickoIme = noviStudent.Ime + "." + noviStudent.Prezime;
			noviNalog.Lozinka = "0000";
			_context.KorisnickiNalozi.Add(noviNalog);
			_context.SaveChanges();

			noviStudent.KorisnickiNalogId = noviNalog.Id;
			_context.Studenti.Update(noviStudent);
			_context.SaveChanges();
			return Redirect("/RecepcionerModul/Studenti/Index");
		}

		public IActionResult Obrisi(int id)
		{
			Student s = _context.Studenti.Where(x => x.Id == id).FirstOrDefault();

			StudentSoba ss =_context.StudentiSobe.Where(x => x._StudentId == id).FirstOrDefault(); //Soba u kojoj je bio kako bi oslobodili mjesto
			if (ss != null)
			{
				int idSobe = ss._SobaId;
				Soba soba = _context.Sobe.Where(x => x.Id == idSobe).FirstOrDefault();
				if (soba.BrojKreveta!=0)
				{
					soba.BrojKreveta--;
				}
				

				_context.StudentiSobe.Remove(ss);
			
				_context.Sobe.Update(soba);
				_context.SaveChanges();
			}

			KorisnickiNalog kn = _context.KorisnickiNalozi.Where(x => x.KorisnickoIme == s.Ime + "." + s.Prezime).FirstOrDefault();
			if (kn != null) {
				_context.KorisnickiNalozi.Remove(kn);
				_context.SaveChanges();
			}
			_context.Studenti.Remove(s);
			_context.SaveChanges();


			return Redirect("/RecepcionerModul/Studenti/Index");
		}

		public IActionResult Detalji(int id)
		{
			int sobaId;
			StudentSoba stSo =_context.StudentiSobe.Where(s => s._StudentId == id).FirstOrDefault();
			if (stSo!=null)
			{
				sobaId = stSo._SobaId;
			}

			StudentiDetaljiVM model = _context.Studenti.Where(x => x.Id == id).Select(x => new StudentiDetaljiVM {
				Id = x.Id,
				Ime = x.Ime,
				Prezime = x.Prezime,
				Spol = x.Spol,
				Jmbg = x.JMBG,
				Grad = x._Grad.Naziv,
				Email = x.Mail,
				Soba_ = _context.StudentiSobe.Where(s => s._StudentId == x.Id).FirstOrDefault()._Soba.Naziv,
				Fakultet = x._Fakultet.Naziv,
				DatumRodjenja = x.DatumRodjenja.ToString(),
				DatumUpisa = _context.StudentiSobe.Where(s => s._StudentId == id).FirstOrDefault().DatumDodjele.ToString(),
				Username=_context.KorisnickiNalozi.Where(s=>s.KorisnickoIme==x.Ime+"."+x.Prezime).FirstOrDefault().KorisnickoIme,
				Password=  _context.KorisnickiNalozi.Where(s => s.KorisnickoIme == x.Ime + "." + x.Prezime).FirstOrDefault().Lozinka,
				Adresa=x.Adresa,
				Telefon=x.Telefon

			}).FirstOrDefault();

			//List<StudentSoba> studenti = _context.StudentiSobe.Where(s => s._SobaId == sobaId).ToList();
			//if (studenti != null)
			//{
			//	foreach (var x in studenti)
			//	{
			//		model.studentiSaKojimaDijeliSobu.Add(x._Student.Ime + " " + x._Student.Prezime);
			//	}
			//}

			return View("Detalji",model);
		}
	}
}