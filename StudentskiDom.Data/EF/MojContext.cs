using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using StudentskiDom.Data.Models;

namespace StudentskiDom.Data.EF
{
   public class MojContext: DbContext
    {
		public DbSet<Drzava> Drzave { get; set; }
		public DbSet<Regija> Regije { get; set; }
		public DbSet<Grad> Gradovi { get; set; }
		public DbSet<AkademskaGodina> AkademskeGodine { get; set; }
		public DbSet<Fakultet> Fakulteti { get; set; }
		public DbSet<Student> Studenti { get; set; }
		public DbSet<Posjetilac> Pojsjetioci { get; set; }
		public DbSet<VrstaZaposlenika> VrsteZaposlenika { get; set; }
		public DbSet<Zaposlenik> Zaposlenici { get; set; }
		public DbSet<Soba> Sobe { get; set; }
		public DbSet<Sala> Sale { get; set; }
		public DbSet<TipUplate> TipoviUplata { get; set; }
		public DbSet<TipSobe> TipoviSoba { get; set; }
		public DbSet<VesMasina> VesMasine { get; set; }
		public DbSet<StudentSoba> StudentiSobe { get; set; }
		public DbSet<TerminVeseraja> TerminiVeseraja { get; set; }
		public DbSet<RezervacijaSale> RezervacijeSale { get; set; }
		public DbSet<Uplata> Uplate { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost;Database=BazaStudentskiDom;Trusted_Connection=True;MultipleActiveResultSets=true;User ID=sa;Password=test");
		}


	}
}
