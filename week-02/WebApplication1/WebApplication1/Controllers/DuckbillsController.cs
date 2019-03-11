using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DuckbillsController : Controller
    {
        private readonly WebApplication1Context _context;

        static List<Duckbill> duckbills = new List<Duckbill>()
        {
            new Duckbill() { Id = Guid.NewGuid(), Name = "Perry" },
            new Duckbill() { Id = Guid.NewGuid(), Name = "Stanley" },
        };

        public DuckbillsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Duckbills
        public IActionResult Index()
        {
            return View(duckbills);
        }

        // GET: Duckbills/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duckbill = duckbills.FirstOrDefault(db => db.Id == id);
            if (duckbill == null)
            {
                return NotFound();
            }

            return View(duckbill);
        }

        // GET: Duckbills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Duckbills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Duckbill duckbill)
        {
            if (ModelState.IsValid)
            {
                duckbill.Id = Guid.NewGuid();

                duckbills.Add(duckbill);

                return RedirectToAction(nameof(Index));
            }
            return View(duckbill);
        }

        // GET: Duckbills/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duckbill = await _context.Duckbill.FindAsync(id);
            if (duckbill == null)
            {
                return NotFound();
            }
            return View(duckbill);
        }

        // POST: Duckbills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Duckbill duckbill)
        {
            if (id != duckbill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duckbill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuckbillExists(duckbill.Id))
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
            return View(duckbill);
        }

        // GET: Duckbills/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duckbill = await _context.Duckbill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duckbill == null)
            {
                return NotFound();
            }

            return View(duckbill);
        }

        // POST: Duckbills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var duckbill = await _context.Duckbill.FindAsync(id);
            _context.Duckbill.Remove(duckbill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuckbillExists(Guid id)
        {
            return _context.Duckbill.Any(e => e.Id == id);
        }
    }
}
