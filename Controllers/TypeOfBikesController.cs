using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeRentProjects.Data;
using BikeRentProjects.Models;

namespace BikeRentProjects.Controllers
{
    public class TypeOfBikesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeOfBikesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeOfBikes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeOfBike.ToListAsync());
        }

        // GET: TypeOfBikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfBike = await _context.TypeOfBike
                .FirstOrDefaultAsync(m => m.ID == id);
            if (typeOfBike == null)
            {
                return NotFound();
            }

            return View(typeOfBike);
        }

        // GET: TypeOfBikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOfBikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeBike,ID")] TypeOfBike typeOfBike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOfBike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfBike);
        }

        // GET: TypeOfBikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfBike = await _context.TypeOfBike.FindAsync(id);
            if (typeOfBike == null)
            {
                return NotFound();
            }
            return View(typeOfBike);
        }

        // POST: TypeOfBikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeBike,ID")] TypeOfBike typeOfBike)
        {
            if (id != typeOfBike.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOfBike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfBikeExists(typeOfBike.ID))
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
            return View(typeOfBike);
        }

        // GET: TypeOfBikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfBike = await _context.TypeOfBike
                .FirstOrDefaultAsync(m => m.ID == id);
            if (typeOfBike == null)
            {
                return NotFound();
            }

            return View(typeOfBike);
        }

        // POST: TypeOfBikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeOfBike = await _context.TypeOfBike.FindAsync(id);
            if (typeOfBike != null)
            {
                _context.TypeOfBike.Remove(typeOfBike);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOfBikeExists(int id)
        {
            return _context.TypeOfBike.Any(e => e.ID == id);
        }
    }
}
