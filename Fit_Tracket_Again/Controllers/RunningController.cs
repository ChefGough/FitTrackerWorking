using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fit_Tracket_Again.Models;

namespace Fit_Tracket_Again.Controllers
{
    public class RunningController : Controller
    {
        private readonly Fit_Tracket_AgainContext _context;

        public RunningController(Fit_Tracket_AgainContext context)
        {
            _context = context;
        }

        // GET: Running
        public async Task<IActionResult> Index()
        {
            return View(await _context.Running.ToListAsync());
        }

        // GET: Running/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var running = await _context.Running
                .FirstOrDefaultAsync(m => m.ID == id);
            if (running == null)
            {
                return NotFound();
            }

            return View(running);
        }

        // GET: Running/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Running/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Distance,Time,RunType")] Running running)
        {
            if (ModelState.IsValid)
            {
                _context.Add(running);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(running);
        }

        // GET: Running/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var running = await _context.Running.FindAsync(id);
            if (running == null)
            {
                return NotFound();
            }
            return View(running);
        }

        // POST: Running/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,Distance,Time,RunType")] Running running)
        {
            if (id != running.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(running);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunningExists(running.ID))
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
            return View(running);
        }

        // GET: Running/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var running = await _context.Running
                .FirstOrDefaultAsync(m => m.ID == id);
            if (running == null)
            {
                return NotFound();
            }

            return View(running);
        }

        // POST: Running/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var running = await _context.Running.FindAsync(id);
            _context.Running.Remove(running);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunningExists(int id)
        {
            return _context.Running.Any(e => e.ID == id);
        }
    }
}
