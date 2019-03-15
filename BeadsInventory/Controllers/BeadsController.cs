using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeadsInventory.Models;

namespace BeadsInventory.Controllers{

    public class BeadsController : Controller{

        private readonly BeadContext _context;

        public BeadsController(BeadContext context){
            _context = context;
        }

        // GET: Beads
        public async Task<IActionResult> Index(){
            return View(await _context.Bead.ToListAsync());
        }

        // GET: Beads/Details/5
        public async Task<IActionResult> Details(int? id){
            if (id == null){
                return NotFound();
            }
            var bead = await _context.Bead
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bead == null){
                return NotFound();
            }
            return View(bead);
        }

        // GET: Beads/Create
        public IActionResult Create(){
            return View();
        }

        // POST: Beads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Material,Shape,Color,Size_MM,Quantity,Price_Point")] Bead bead){
            if (ModelState.IsValid){
                _context.Add(bead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bead);
        }

        // GET: Beads/Edit/5
        public async Task<IActionResult> Edit(int? id){
            if (id == null){
                return NotFound();
            }
            var bead = await _context.Bead.FindAsync(id);
            if (bead == null){
                return NotFound();
            }
            return View(bead);
        }

        // POST: Beads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Material,Shape,Color,Size_MM,Quantity,Price_Point")] Bead bead){
            if (id != bead.ID){
                return NotFound();
            }
            if (ModelState.IsValid){
                try{
                    _context.Update(bead);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException){
                    if (!BeadExists(bead.ID)){
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bead);
        }

        // GET: Beads/Delete/5
        public async Task<IActionResult> Delete(int? id){
            if (id == null){
                return NotFound();
            }
            var bead = await _context.Bead
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bead == null){
                return NotFound();
            }
            return View(bead);
        }

        // POST: Beads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id){
            var bead = await _context.Bead.FindAsync(id);
            _context.Bead.Remove(bead);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeadExists(int id){
            return _context.Bead.Any(e => e.ID == id);
        }
    }
}
