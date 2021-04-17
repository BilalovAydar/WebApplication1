using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClasssesController : Controller
    {
        private readonly MvcWebContext _context;

        public ClasssesController(MvcWebContext context)
        {
            _context = context;
        }

        // GET: Classses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classs.ToListAsync());
        }

        // GET: Classses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classs = await _context.Classs
                .FirstOrDefaultAsync(m => m.id == id);
            if (classs == null)
            {
                return NotFound();
            }

            return View(classs);
        }

        // GET: Classses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,NameOfClass")] Classs classs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classs);
        }

        // GET: Classses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classs = await _context.Classs.FindAsync(id);
            if (classs == null)
            {
                return NotFound();
            }
            return View(classs);
        }

        // POST: Classses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,NameOfClass")] Classs classs)
        {
            if (id != classs.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasssExists(classs.id))
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
            return View(classs);
        }

        // GET: Classses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classs = await _context.Classs
                .FirstOrDefaultAsync(m => m.id == id);
            if (classs == null)
            {
                return NotFound();
            }

            return View(classs);
        }

        // POST: Classses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classs = await _context.Classs.FindAsync(id);
            _context.Classs.Remove(classs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasssExists(int id)
        {
            return _context.Classs.Any(e => e.id == id);
        }
    }
}
