using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Data.Models
{
	public class TerminVeseraja
	{
		[Key]
		public int Id { get; set; }
		public DateTime DatumKoristenja { get; set; }
		public int VrijemeKoristenja { get; set; }

		public VesMasina _VesMasina { get; set; }
		[ForeignKey(nameof(_VesMasina))]
		public int _VesMasinaId { get; set; }

		public StudentSoba _StudentSoba { get; set; }
		[ForeignKey(nameof(_StudentSoba))]
		public int _StudentSobaId { get; set; }

	}
}
