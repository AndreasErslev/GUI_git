using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BreakfastBuffet2.Data;
using Morgenmadsbuffeten_GruppeTo.Models.Entity;
using Microsoft.AspNetCore.Authorization;

namespace BreakfastBuffet2.Controllers
{
    [Authorize]
    public class GuestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Guests
        public async Task<IActionResult> Reception()
        {
            var applicationDbContext = _context.Guest;
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Bookings()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View();
        }


        public async Task<IActionResult> Kitchen()
        {
            var applicationDbContext = _context.Guest;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Guests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest
                //.Include(g => g.BreakfastBuffetDb)
                .FirstOrDefaultAsync(m => m.GuestId == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // GET: Guests/Create
        public async Task<IActionResult> Restaurant()
        {
            var applicationDbContext = _context.Guest;
            return View(await applicationDbContext.ToListAsync());
        }

        // POST: Guests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCheckIn(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guest);
                //_checkedInGuests.Add(guest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Restaurant));
            }
                        //ViewData["BreakfastBuffetDBId"] = new SelectList(_context.Set<BreakfastBuffetDB>(), "BreakfastBuffetDBId", "BreakfastBuffetDBId", guest.BreakfastBuffetDBId);
            return View(guest);
        }

        // GET: Guests/Edit/5
        public async Task<IActionResult> Check_In(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            //ViewData["BreakfastBuffetDBId"] = new SelectList(_context.Set<BreakfastBuffetDB>(), "BreakfastBuffetDBId", "BreakfastBuffetDBId", guest.BreakfastBuffetDBId);
            return View(guest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Check_In(int id, Guest guest)
        {
            if (id != guest.GuestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestExists(guest.GuestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Restaurant));
            }
            //ViewData["BreakfastBuffetDBId"] = new SelectList(_context.Set<BreakfastBuffetDB>(), "BreakfastBuffetDBId", "BreakfastBuffetDBId", guest.BreakfastBuffetDBId);
            return View(guest);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBookings(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guest);
                //_bookedGuests.Add(guest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Bookings));
            }
            //ViewData["BreakfastBuffetDBId"] = new SelectList(_context.Set<BreakfastBuffetDB>(), "BreakfastBuffetDBId", "BreakfastBuffetDBId", guest.BreakfastBuffetDBId);
            return View(guest);
        }

        // GET: Guests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            //ViewData["BreakfastBuffetDBId"] = new SelectList(_context.Set<BreakfastBuffetDB>(), "BreakfastBuffetDBId", "BreakfastBuffetDBId", guest.BreakfastBuffetDBId);
            return View(guest);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Guest guest)
        {
            if (id != guest.GuestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestExists(guest.GuestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Reception));
            }
            //ViewData["BreakfastBuffetDBId"] = new SelectList(_context.Set<BreakfastBuffetDB>(), "BreakfastBuffetDBId", "BreakfastBuffetDBId", guest.BreakfastBuffetDBId);
            return View(guest);
        }

        // GET: Guests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest
                //.Include(g => g.BreakfastBuffetDb)
                .FirstOrDefaultAsync(m => m.GuestId == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guest = await _context.Guest.FindAsync(id);
            _context.Guest.Remove(guest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Reception));
        }

        private bool GuestExists(int id)
        {
            return _context.Guest.Any(e => e.GuestId == id);
        }
    }
}
