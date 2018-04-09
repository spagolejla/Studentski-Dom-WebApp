using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentskiDom.Data.EF;
using StudentskiDom.Data.Models;

namespace StudentskiDom.Web.Areas.RecepcionerModul.Controllers
{
    [Area("RecepcionerModul")]
    public class DrzavasController : Controller
    {
        private readonly MojContext _context;

        public DrzavasController(MojContext context)
        {
            _context = context;
        }

        // GET: RecepcionerModul/Drzavas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drzave.ToListAsync());
        }

        // GET: RecepcionerModul/Drzavas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drzava = await _context.Drzave
                .SingleOrDefaultAsync(m => m.Id == id);
            if (drzava == null)
            {
                return NotFound();
            }

            return View(drzava);
        }

        // GET: RecepcionerModul/Drzavas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecepcionerModul/Drzavas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] Drzava drzava)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drzava);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drzava);
        }

        // GET: RecepcionerModul/Drzavas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drzava = await _context.Drzave.SingleOrDefaultAsync(m => m.Id == id);
            if (drzava == null)
            {
                return NotFound();
            }
            return View(drzava);
        }

        // POST: RecepcionerModul/Drzavas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] Drzava drzava)
        {
            if (id != drzava.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drzava);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrzavaExists(drzava.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(drzava);
        }

        // GET: RecepcionerModul/Drzavas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drzava = await _context.Drzave
                .SingleOrDefaultAsync(m => m.Id == id);
            if (drzava == null)
            {
                return NotFound();
            }

            return View(drzava);
        }

        // POST: RecepcionerModul/Drzavas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drzava = await _context.Drzave.SingleOrDefaultAsync(m => m.Id == id);
            _context.Drzave.Remove(drzava);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrzavaExists(int id)
        {
            return _context.Drzave.Any(e => e.Id == id);
        }
    }
}
