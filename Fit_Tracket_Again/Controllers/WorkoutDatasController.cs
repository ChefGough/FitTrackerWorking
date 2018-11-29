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
    public class WorkoutDatasController : Controller
    {
        private readonly Fit_Tracket_AgainContext _context;

        public WorkoutDatasController(Fit_Tracket_AgainContext context)
        {
            _context = context;
        }

        // GET: WorkoutDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkoutData.ToListAsync());
        }

        // GET: WorkoutDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutData = await _context.WorkoutData
                .FirstOrDefaultAsync(m => m.ID == id);
            if (workoutData == null)
            {
                return NotFound();
            }

            return View(workoutData);
        }

        // GET: WorkoutDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkoutDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,WorkoutTime,WorkoutName,WorkoutWeight,WorkoutReps,WorkoutSets")] WorkoutData workoutData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutData);
        }

        // GET: WorkoutDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutData = await _context.WorkoutData.FindAsync(id);
            if (workoutData == null)
            {
                return NotFound();
            }
            return View(workoutData);
        }

        // POST: WorkoutDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,WorkoutTime,WorkoutName,WorkoutWeight,WorkoutReps,WorkoutSets")] WorkoutData workoutData)
        {
            if (id != workoutData.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutDataExists(workoutData.ID))
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
            return View(workoutData);
        }

        // GET: WorkoutDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutData = await _context.WorkoutData
                .FirstOrDefaultAsync(m => m.ID == id);
            if (workoutData == null)
            {
                return NotFound();
            }

            return View(workoutData);
        }

        // POST: WorkoutDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutData = await _context.WorkoutData.FindAsync(id);
            _context.WorkoutData.Remove(workoutData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutDataExists(int id)
        {
            return _context.WorkoutData.Any(e => e.ID == id);
        }
    }
}
