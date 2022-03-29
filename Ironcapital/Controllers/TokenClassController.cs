using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ironcapital.Data;
using Ironcapital.Models;

namespace Ironcapital.Controllers
{
    public class TokenClassController : Controller
    {
        private readonly DbDataContextClass _context;

        public TokenClassController(DbDataContextClass context)
        {
            _context = context;
        }

        // GET: TokenClass
        public async Task<IActionResult> Index()
        {
            return View(await _context.Token.ToListAsync());
        }

        // GET: TokenClass/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tokenClass = await _context.Token
                .FirstOrDefaultAsync(m => m.TokenId == id);
            if (tokenClass == null)
            {
                return NotFound();
            }

            return View(tokenClass);
        }

        // GET: TokenClass/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TokenClass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TokenId,Name,Price,Owner,DateCreated")] TokenClass tokenClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tokenClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tokenClass);
        }

        // GET: TokenClass/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tokenClass = await _context.Token.FindAsync(id);
            if (tokenClass == null)
            {
                return NotFound();
            }
            return View(tokenClass);
        }

        // POST: TokenClass/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TokenId,Name,Price,Owner,DateCreated")] TokenClass tokenClass)
        {
            if (id != tokenClass.TokenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tokenClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TokenClassExists(tokenClass.TokenId))
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
            return View(tokenClass);
        }

        // GET: TokenClass/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tokenClass = await _context.Token
                .FirstOrDefaultAsync(m => m.TokenId == id);
            if (tokenClass == null)
            {
                return NotFound();
            }

            return View(tokenClass);
        }

        // POST: TokenClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tokenClass = await _context.Token.FindAsync(id);
            _context.Token.Remove(tokenClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TokenClassExists(int id)
        {
            return _context.Token.Any(e => e.TokenId == id);
        }
    }
}
