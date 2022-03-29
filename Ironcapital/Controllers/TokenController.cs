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
    public class TokenController : Controller
    {
        private readonly DbDataContextClass _context;

        public TokenController(DbDataContextClass context)
        {
            _context = context;
        }


        // GET: Token
        public async Task<IActionResult> Index()
        {
            return View(await _context.Token.ToListAsync());
        }

        // GET: Token/Details/5
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

        [Authorize]
        // GET: Token/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Token/Create
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

        [Authorize]
        // GET: Token/Edit/5
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

        // POST: Token/Edit/5
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

        [Authorize]
        // GET: Token/Delete/5
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

        // POST: Token/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tokenClass = await _context.Token.FindAsync(id);
            _context.Token.Remove(tokenClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> List()
        {
            return View(await _context.Token.ToListAsync());
        }

        private bool TokenClassExists(int id)
        {
            return _context.Token.Any(e => e.TokenId == id);
        }
    }
}
