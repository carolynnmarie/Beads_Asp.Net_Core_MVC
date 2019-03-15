using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeadsInventory.Models;

namespace BeadsInventory.Controllers
{
    public class StringingMaterialsController : Controller
    {
        private readonly StringingMaterialContext _context;

        public StringingMaterialsController(StringingMaterialContext context)
        {
            _context = context;
        }

        // GET: StringingMaterials
        public async Task<IActionResult> Index()
        {
            return View(await _context.StringingMaterial.ToListAsync());
        }

        // GET: StringingMaterials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stringingMaterial = await _context.StringingMaterial
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stringingMaterial == null)
            {
                return NotFound();
            }

            return View(stringingMaterial);
        }

        // GET: StringingMaterials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StringingMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Category,Material,Color,Price_Per_Foot,Brand,Description")] StringingMaterial stringingMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stringingMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stringingMaterial);
        }

        // GET: StringingMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stringingMaterial = await _context.StringingMaterial.FindAsync(id);
            if (stringingMaterial == null)
            {
                return NotFound();
            }
            return View(stringingMaterial);
        }

        // POST: StringingMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Category,Material,Color,Price_Per_Foot,Brand,Description")] StringingMaterial stringingMaterial)
        {
            if (id != stringingMaterial.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stringingMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StringingMaterialExists(stringingMaterial.ID))
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
            return View(stringingMaterial);
        }

        // GET: StringingMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stringingMaterial = await _context.StringingMaterial
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stringingMaterial == null)
            {
                return NotFound();
            }

            return View(stringingMaterial);
        }

        // POST: StringingMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stringingMaterial = await _context.StringingMaterial.FindAsync(id);
            _context.StringingMaterial.Remove(stringingMaterial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StringingMaterialExists(int id)
        {
            return _context.StringingMaterial.Any(e => e.ID == id);
        }
    }
}
