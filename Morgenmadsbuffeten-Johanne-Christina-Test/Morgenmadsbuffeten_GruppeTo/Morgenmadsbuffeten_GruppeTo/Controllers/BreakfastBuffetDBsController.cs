﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten_GruppeTo.Data;
using Morgenmadsbuffeten_GruppeTo.Models.Entity;
using Morgenmadsbuffeten_GruppeTo.Models;

namespace Morgenmadsbuffeten_GruppeTo.Controllers
{
    public class BreakfastBuffetDBsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BreakfastBuffetDBsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Reception()
        {
            return View();
        }

        public IActionResult Restaurant()
        {
            return View();
        }

        public IActionResult Kitchen()
        {
            return View();
        }

        //// GET: BreakfastBuffetDBs/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var breakfastBuffetDB = await _context.breakfastBuffets
        //        .FirstOrDefaultAsync(m => m.ReceptiontId == id);
        //    if (breakfastBuffetDB == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(breakfastBuffetDB);
        //}

        public async Task<IActionResult> ReceptionList()
        {
            return View(await _context.guests.ToListAsync());
        }

        // GET: BreakfastBuffetDBs/Create
        public IActionResult Create()
        {
            return Reception();
        }

        // POST: BreakfastBuffetDBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _context.guests.Add(guest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ReceptionList));
            }
            return View(guest);
        }

        [HttpGet]
        public async Task<IActionResult> GetCheckIn([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guest = await _context.guests.FindAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckIn([Bind("RoomNumber, Adult, Child")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guest);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Restaurant));
            }
            //return View(guest);
            return CreatedAtAction(
                "GetCheckIn", new
                {
                    id = guest.GuestId, adult = guest.AdultCount,
                    child = guest.ChildCount, roomNbr = guest.RoomNbr
                }, guest
            );
        }

        // GET: BreakfastBuffetDBs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var breakfastBuffetDB = await _context.breakfastBuffets.FindAsync(id);
        //    if (breakfastBuffetDB == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(breakfastBuffetDB);
        //}

        // POST: BreakfastBuffetDBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ReceptiontId")] BreakfastBuffetDB breakfastBuffetDB)
        //{
        //    if (id != breakfastBuffetDB.ReceptiontId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(breakfastBuffetDB);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BreakfastBuffetDBExists(breakfastBuffetDB.ReceptiontId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(breakfastBuffetDB);
        //}

        // GET: BreakfastBuffetDBs/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var breakfastBuffetDB = await _context.breakfastBuffets
        //        .FirstOrDefaultAsync(m => m.ReceptiontId == id);
        //    if (breakfastBuffetDB == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(breakfastBuffetDB);
        //}

        // POST: BreakfastBuffetDBs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var breakfastBuffetDB = await _context.breakfastBuffets.FindAsync(id);
        //    _context.breakfastBuffets.Remove(breakfastBuffetDB);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BreakfastBuffetDBExists(int id)
        //{
        //    return _context.breakfastBuffets.Any(e => e.ReceptiontId == id);
        //}
    }
}
