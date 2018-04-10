﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Web.Areas.RecepcionerModul.ViewModels
{
    public class StudentiIndexVM
    {
		public List<Row> Rows { get; set; }
		public class Row
		{
			public int Id { get; set; }
			public string Ime { get; set; }
			public string Prezime { get; set; }
			public string Spol { get; set; }
			public string Jmbg { get; set; }
			public string Email { get; set; }
			public string Soba_ { get; set; }
			public string Grad { get; set; }

		}

	}
}
