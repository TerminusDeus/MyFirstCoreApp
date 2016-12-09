using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstCoreApp.Data;
using MyFirstCoreApp.Models;

namespace MyFirstCoreApp.Controllers
{
    public class RewardingsController : Controller
    {
        private readonly RewardingContext _context;

        public RewardingsController(RewardingContext context)
        {
            _context = context;    
        }

        // GET: Rewardings
        public async Task<IActionResult> Index()
        {
            var rewardingContext = _context.Rewardings.Include(r => r.Award).Include(r => r.User);
            return View(await rewardingContext.ToListAsync());
        }

        // GET: Rewardings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewarding = await _context.Rewardings.SingleOrDefaultAsync(m => m.RewardingID == id);
            if (rewarding == null)
            {
                return NotFound();
            }

            return View(rewarding);
        }

        // GET: Rewardings/Create
        public IActionResult Create()
        {
            ViewData["AwardID"] = new SelectList(_context.Awards, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: Rewardings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RewardingID,AwardID,UserID")] Rewarding rewarding)
        {
            if (ModelState.IsValid)
            {
                // TO-DO: IMPROVE
                try
                {
                    _context.Add(rewarding);
                    await _context.SaveChangesAsync();
                }
                catch (Exception){}
                return RedirectToAction("Index");
            }
            ViewData["AwardID"] = new SelectList(_context.Awards, "ID", "ID", rewarding.AwardID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", rewarding.UserID);
            return View(rewarding);
        }

        // GET: Rewardings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewarding = await _context.Rewardings.SingleOrDefaultAsync(m => m.RewardingID == id);
            if (rewarding == null)
            {
                return NotFound();
            }
            ViewData["AwardID"] = new SelectList(_context.Awards, "ID", "ID", rewarding.AwardID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", rewarding.UserID);
            return View(rewarding);
        }

        // POST: Rewardings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RewardingID,AwardID,UserID")] Rewarding rewarding)
        {
            if (id != rewarding.RewardingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rewarding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RewardingExists(rewarding.RewardingID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["AwardID"] = new SelectList(_context.Awards, "ID", "ID", rewarding.AwardID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", rewarding.UserID);
            return View(rewarding);
        }

        // GET: Rewardings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewarding = await _context.Rewardings.SingleOrDefaultAsync(m => m.RewardingID == id);
            if (rewarding == null)
            {
                return NotFound();
            }

            return View(rewarding);
        }

        // POST: Rewardings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rewarding = await _context.Rewardings.SingleOrDefaultAsync(m => m.RewardingID == id);
            _context.Rewardings.Remove(rewarding);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RewardingExists(int id)
        {
            return _context.Rewardings.Any(e => e.RewardingID == id);
        }
    }
}
