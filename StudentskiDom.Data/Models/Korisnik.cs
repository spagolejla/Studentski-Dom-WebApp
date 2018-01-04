using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentskiDom.Data.Models
{
   public  class Korisnik
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public List<Student> Studenti { get; set; }

        public Student Student
        {
            get
            {
                return Studenti.FirstOrDefault();
            }
        }

        public List<Zaposlenik> Zaposlenici { get; set; }
        public Zaposlenik Zaposlenik
        {
            get
            {
                return Zaposlenici.FirstOrDefault();
            }
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string Ime_prezime
        {
            get { return Ime + " " + Prezime; }
        }

        public string Prezime_ime
        {
            get { return Prezime + " " + Ime; }
        }

    }
}
