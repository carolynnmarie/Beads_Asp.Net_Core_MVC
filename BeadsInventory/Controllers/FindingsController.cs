using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeadsInventory.Models;

namespace BeadsInventory.Controllers {

    public class FindingsController : Controller {

        private readonly FindingContext _context;

        public FindingsController(FindingContext context){
            _context = context;
        }

        // GET: Findings
        public async Task<IActionResult> Index(){
            return View(await _context.Finding.ToListAsync());
        }

        // GET: Findings/Details/5
        public async Task<IActionResult> Details(int? id){
            var finding = await _context.Finding.FirstOrDefaultAsync(m => m.ID == id);
            if (id == null){
                return NotFound();
            }
            if (finding == null){
                return NotFound();
            }
            return View(finding);
        }

        // GET: Findings/Create
        public IActionResult Create(){
            return View();
        }

        // POST: Findings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FindingCategory,Material,Description,Color,Length_CM,Price_Point,Brand")] Finding finding){
            if (ModelState.IsValid){
                _context.Add(finding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(finding);
        }

        // GET: Findings/Edit/5
        public async Task<IActionResult> Edit(int? id){
            var finding = await _context.Finding.FindAsync(id);
            if (id == null){
                return NotFound();
            }
            if (finding == null){
                return NotFound();
            }
            return View(finding);
        }

        // POST: Findings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FindingCategory,Material,Description,Color,Length_CM,Price_Point,Brand")] Finding finding){
            if (id != finding.ID){
                return NotFound();
            }
            if (ModelState.IsValid){
                try {
                   _context.Update(finding);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!FindingExists(finding.ID)){
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(finding);
        }

        // GET: Findings/Delete/5
        public async Task<IActionResult> Delete(int? id){
            var finding = await _context.Finding.FirstOrDefaultAsync(m => m.ID == id);
            if (id == null){
                return NotFound();
            }
            if (finding == null){
                return NotFound();
            }
            return View(finding);
        }

        // POST: Findings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id){
            var finding = await _context.Finding.FindAsync(id);
            _context.Finding.Remove(finding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FindingExists(int id){
            return _context.Finding.Any(e => e.ID == id);
        }
    }
}
