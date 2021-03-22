using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSnack.Data;
using MvcSnack.Models;

namespace MvcSnack.Controllers
{
    public class SnacksController : Controller
    {
        private readonly MvcSnackContext _context;

        public SnacksController(MvcSnackContext context)
        {
            _context = context;
        }

        // GET: Snacks
        public async Task<IActionResult> Index(string snackType, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> typeQuery = from m in _context.Snack
                                            orderby m.Types
                                            select m.Types;

            var snacks = from m in _context.Snack
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                snacks = snacks.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(snackType))
            {
                snacks = snacks.Where(x => x.Types == snackType);
            }

            var snackTypeVM = new SnackTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Snacks = await snacks.ToListAsync()
            };

            return View(snackTypeVM);
        }

        // GET: Snacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snack = await _context.Snack
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snack == null)
            {
                return NotFound();
            }

            return View(snack);
        }

        // GET: Snacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Snacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Types,Price,Company")] Snack snack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(snack);
        }

        // GET: Snacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snack = await _context.Snack.FindAsync(id);
            if (snack == null)
            {
                return NotFound();
            }
            return View(snack);
        }

        // POST: Snacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Types,Price")] Snack snack)
        {
            if (id != snack.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnackExists(snack.Id))
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
            return View(snack);
        }

        // GET: Snacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snack = await _context.Snack
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snack == null)
            {
                return NotFound();
            }

            return View(snack);
        }

        // POST: Snacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snack = await _context.Snack.FindAsync(id);
            _context.Snack.Remove(snack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnackExists(int id)
        {
            return _context.Snack.Any(e => e.Id == id);
        }
    }
}
