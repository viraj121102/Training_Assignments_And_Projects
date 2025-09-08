using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Transport_Management_System.Data;
using Transport_Management_System.Models;

namespace Transport_Management_System.Controllers
{
    public class TripsController : Controller
    {
        private readonly TmsDbContext _context;

        public TripsController(TmsDbContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            var tmsDbContext = _context.Trips.Include(t => t.Route).Include(t => t.Vehicle);
            return View(await tmsDbContext.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Route)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            ViewData["RouteID"] = new SelectList(_context.Routes, "RouteID", "EndDestination");
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "VehicleID", "Model");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripID,VehicleID,RouteID,DepartureDate,ArrivalDate,Status,TripType,MaxPassengers")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteID"] = new SelectList(_context.Routes, "RouteID", "EndDestination", trip.RouteID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "VehicleID", "Model", trip.VehicleID);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["RouteID"] = new SelectList(_context.Routes, "RouteID", "EndDestination", trip.RouteID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "VehicleID", "Model", trip.VehicleID);
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripID,VehicleID,RouteID,DepartureDate,ArrivalDate,Status,TripType,MaxPassengers")] Trip trip)
        {
            if (id != trip.TripID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripID))
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
            ViewData["RouteID"] = new SelectList(_context.Routes, "RouteID", "EndDestination", trip.RouteID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "VehicleID", "Model", trip.VehicleID);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Route)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.TripID == id);
        }
    }
}
