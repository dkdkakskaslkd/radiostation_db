using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using radiostation_db.Data;
using radiostation_db.Models;

namespace Web_radiostation_db.Controllers
{
    public class ДолжностиController : Controller
    {
        private readonly radiostationContext _context;

        public ДолжностиController(radiostationContext context)
        {
            _context = context;
        }

        // GET: Должности
        public async Task<IActionResult> Index()
        {
            return View(await _context.Должности.ToListAsync());
        }

        // GET: Должности/Details/5
        public async Task<IActionResult> Details(Byte[] id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var должности = await _context.Должности
                .FirstOrDefaultAsync(m => m.КодДолжности == id);
            if (должности == null)
            {
                return NotFound();
            }

            return View(должности);
        }

        // GET: Должности/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Должности/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("НаименованиеДолжности,Оклад,Обязанности,Требования,КодДолжности")] Должности должности)
        {
            if (ModelState.IsValid)
            {
                _context.Add(должности);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(должности);
        }

        // GET: Должности/Edit/5
        public async Task<IActionResult> Edit(Byte[] id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var должности = await _context.Должности.FindAsync(id);
            if (должности == null)
            {
                return NotFound();
            }
            return View(должности);
        }

        // POST: Должности/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Byte[] id, [Bind("НаименованиеДолжности,Оклад,Обязанности,Требования,КодДолжности")] Должности должности)
        {
            if (id != должности.КодДолжности)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(должности);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ДолжностиExists(должности.КодДолжности))
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
            return View(должности);
        }

        // GET: Должности/Delete/5
        public async Task<IActionResult> Delete(Byte[] id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var должности = await _context.Должности
                .FirstOrDefaultAsync(m => m.КодДолжности == id);
            if (должности == null)
            {
                return NotFound();
            }

            return View(должности);
        }

        // POST: Должности/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Byte[] id)
        {
            var должности = await _context.Должности.FindAsync(id);
            _context.Должности.Remove(должности);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ДолжностиExists(Byte[] id)
        {
            return _context.Должности.Any(e => e.КодДолжности == id);
        }
    }
}
