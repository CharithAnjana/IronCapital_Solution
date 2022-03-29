using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ironcapital.Data;
using Ironcapital.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ironcapital.Controllers
{
    public class BuyNowController : Controller
    {
        private readonly DbDataContextClass _context;

        public BuyNowController(DbDataContextClass context)
        {
            _context = context;
        }

        [Authorize]
        // GET: BuyNow
        public async Task<IActionResult> Index()
        {
            var dbDataContextClass = _context.BuyNow.Include(b => b.TokenClass);
            return View(await dbDataContextClass.ToListAsync());
        }




        [Authorize]
        // GET: BuyNow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyNowClass = await _context.BuyNow
                .Include(b => b.TokenClass)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (buyNowClass == null)
            {
                return NotFound();
            }

            return View(buyNowClass);
        }




        // GET: BuyNow/Create
        public IActionResult Form(int? id)
        {
            ViewData["TokenId"] = new SelectList(_context.Token, "TokenId", "Name", id);
            return View();
        }

        // POST: BuyNow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Form([Bind("OrderId,FullName,Email,Phone,TokenId,WalletAddress,TwitterID,Message,RecBy")] BuyNowClass buyNowClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyNowClass);
                await _context.SaveChangesAsync();

                ViewBag.suc = "Your order is saved!";
                ViewData["TokenId"] = new SelectList(_context.Token, "TokenId", "Name",buyNowClass.TokenId);
                ModelState.Clear();
                return View();
            }
            ViewData["TokenId"] = new SelectList(_context.Token, "TokenId", "Name", buyNowClass.TokenId);
            return View(buyNowClass);
        }





        [Authorize]
        // GET: BuyNow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyNowClass = await _context.BuyNow.FindAsync(id);
            if (buyNowClass == null)
            {
                return NotFound();
            }
            ViewData["TokenId"] = new SelectList(_context.Token, "TokenId", "Name", buyNowClass.TokenId);
            return View(buyNowClass);
        }

        // POST: BuyNow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,FullName,Email,Phone,TokenId,WalletAddress,TwitterID,Message,RecBy")] BuyNowClass buyNowClass)
        {
            if (id != buyNowClass.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyNowClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyNowClassExists(buyNowClass.OrderId))
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
            ViewData["TokenId"] = new SelectList(_context.Token, "TokenId", "Name", buyNowClass.TokenId);
            return View(buyNowClass);
        }





        [Authorize]
        // GET: BuyNow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyNowClass = await _context.BuyNow
                .Include(b => b.TokenClass)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (buyNowClass == null)
            {
                return NotFound();
            }

            return View(buyNowClass);
        }

        // POST: BuyNow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buyNowClass = await _context.BuyNow.FindAsync(id);
            _context.BuyNow.Remove(buyNowClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyNowClassExists(int id)
        {
            return _context.BuyNow.Any(e => e.OrderId == id);
        }
    }
}
