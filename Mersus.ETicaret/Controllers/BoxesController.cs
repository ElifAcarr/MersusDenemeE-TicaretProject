using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mersus.ETicaret.Database;
using Mersus.ETicaret.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.CodeAnalysis;

namespace Mersus.ETicaret.Controllers
{
    public class BoxesController : Controller
    {
        private readonly ETicaretContext _context;

        public BoxesController(ETicaretContext context)
        {
            _context = context;
        }

        // GET: Boxes
        public async Task<IActionResult> Index()
        {
          
           
              return _context.Boxs != null ? 
                          View(await _context.Boxs.Include(x => x.Product).ToListAsync()) :
                          Problem("Entity set 'ETicaretContext.Boxs'  is null.");
        }

        // GET: Boxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Boxs == null)
            {
                return NotFound();
            }

            var box = await _context.Boxs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (box == null)
            {
                return NotFound();
            }

            return View(box);
        }

        // GET: Boxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,ProductId")] Box box)
        {
            if (ModelState.IsValid)
            {
                _context.Add(box);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(box);
        }

        // GET: Boxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Boxs == null)
            {
                return NotFound();
            }

            var box = await _context.Boxs.Include(x => x.Product).FirstOrDefaultAsync(x=>x.Id==id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);
        }

        // POST: Boxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,ProductId")] Box box)
        {
            if (id != box.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(box);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoxExists(box.Id))
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
            return View(box);
        }

        // GET: Boxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (_context.Boxs == null)
            {
                return Problem("Entity set 'ETicaretContext.Boxs'  is null.");
            }
            var box = await _context.Boxs.FindAsync(id);
            if (box != null)
            {
                _context.Boxs.Remove(box);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Boxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Boxs == null)
            {
                return Problem("Entity set 'ETicaretContext.Boxs'  is null.");
            }
            var box = await _context.Boxs.FindAsync(id);
            if (box != null)
            {
                _context.Boxs.Remove(box);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoxExists(int id)
        {
          return (_context.Boxs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        // POST: Boxes/Delete/5
        [HttpPost, ActionName("OdemeYap")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OdemeYap()
        {
            var d = await _context.Boxs.Include(x => x.Product).ToListAsync();
            if (d.Count > 0)
            { 
                foreach (var box in d)
                {
                    var product=await _context.Products.FindAsync(box.Product.Id);
                    if(product != null)
                    {
                        product.Quantity = product.Quantity - box.Quantity;
                        await _context.SaveChangesAsync();
                    }
                    _context.Boxs.Remove(box);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                return Problem("Sepete ürün ekle fakir misin sen?");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
