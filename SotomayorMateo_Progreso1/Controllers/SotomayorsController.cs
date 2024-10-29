using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SotomayorMateo_Progreso1.Data;
using SotomayorMateo_Progreso1.Models;

namespace SotomayorMateo_Progreso1.Controllers
{
    public class SotomayorsController : Controller
    {
        private readonly SotomayorMateo_Progreso1Context _context;

        public SotomayorsController(SotomayorMateo_Progreso1Context context)
        {
            _context = context;
        }

        // GET: Sotomayors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sotomayor.ToListAsync());
        }

        // GET: Sotomayors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sotomayor = await _context.Sotomayor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sotomayor == null)
            {
                return NotFound();
            }

            return View(sotomayor);
        }

        // GET: Sotomayors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sotomayors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Edad,Ingresos,Nombre,Activo,FechaNacimiento")] Sotomayor sotomayor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sotomayor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sotomayor);
        }

        // GET: Sotomayors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sotomayor = await _context.Sotomayor.FindAsync(id);
            if (sotomayor == null)
            {
                return NotFound();
            }
            return View(sotomayor);
        }

        // POST: Sotomayors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Edad,Ingresos,Nombre,Activo,FechaNacimiento")] Sotomayor sotomayor)
        {
            if (id != sotomayor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sotomayor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SotomayorExists(sotomayor.Id))
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
            return View(sotomayor);
        }

        // GET: Sotomayors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sotomayor = await _context.Sotomayor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sotomayor == null)
            {
                return NotFound();
            }

            return View(sotomayor);
        }

        // POST: Sotomayors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sotomayor = await _context.Sotomayor.FindAsync(id);
            if (sotomayor != null)
            {
                _context.Sotomayor.Remove(sotomayor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SotomayorExists(int id)
        {
            return _context.Sotomayor.Any(e => e.Id == id);
        }
    }
}
