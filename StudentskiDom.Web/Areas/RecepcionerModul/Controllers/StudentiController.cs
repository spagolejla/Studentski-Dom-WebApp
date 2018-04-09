using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentskiDom.Web.Areas.RecepcionerModul.Controllers
{
    public class StudentiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}