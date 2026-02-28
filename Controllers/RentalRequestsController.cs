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
    public class RentalRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RentalRequest.Include(r => r.Bike).Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RentalRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRequest = await _context.RentalRequest
                .Include(r => r.Bike)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rentalRequest == null)
            {
                return NotFound();
            }

            return View(rentalRequest);
        }

        // GET: RentalRequests/Create
        public IActionResult Create()
        {
            ViewData["BikeID"] = new SelectList(_context.Bike, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            return View();
        }

        // POST: RentalRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartDate,EndDate,TotalPrice,Status,BikeID,UserID,ID")] RentalRequest rentalRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BikeID"] = new SelectList(_context.Bike, "ID", "ID", rentalRequest.BikeID);
            ViewData["UserID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", rentalRequest.UserID);
            return View(rentalRequest);
        }

        // GET: RentalRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRequest = await _context.RentalRequest.FindAsync(id);
            if (rentalRequest == null)
            {
                return NotFound();
            }
            ViewData["BikeID"] = new SelectList(_context.Bike, "ID", "ID", rentalRequest.BikeID);
            ViewData["UserID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", rentalRequest.UserID);
            return View(rentalRequest);
        }

        // POST: RentalRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StartDate,EndDate,TotalPrice,Status,BikeID,UserID,ID")] RentalRequest rentalRequest)
        {
            if (id != rentalRequest.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalRequestExists(rentalRequest.ID))
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
            ViewData["BikeID"] = new SelectList(_context.Bike, "ID", "ID", rentalRequest.BikeID);
            ViewData["UserID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", rentalRequest.UserID);
            return View(rentalRequest);
        }

        // GET: RentalRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRequest = await _context.RentalRequest
                .Include(r => r.Bike)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rentalRequest == null)
            {
                return NotFound();
            }

            return View(rentalRequest);
        }

        // POST: RentalRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalRequest = await _context.RentalRequest.FindAsync(id);
            if (rentalRequest != null)
            {
                _context.RentalRequest.Remove(rentalRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalRequestExists(int id)
        {
            return _context.RentalRequest.Any(e => e.ID == id);
        }
    }
}
