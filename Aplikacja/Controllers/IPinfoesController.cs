using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplikacja.Models;

namespace Aplikacja.Controllers
{
    public class IPinfoesController : Controller
    {
        private readonly AplikacjaContext _context;

        public IPinfoesController(AplikacjaContext context)
        {
            _context = context;    
        }

        // GET: IPinfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.IPinfo.ToListAsync());
        }

        // GET: IPinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iPinfo = await _context.IPinfo
                .SingleOrDefaultAsync(m => m.ID == id);
            if (iPinfo == null)
            {
                return NotFound();
            }

            return View(iPinfo);
        }

        // GET: IPinfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IPinfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IPAddress,countryName,countryCode,regionName,cityName,zipCode,timeZone,longitude,latitude")] IPinfo iPinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iPinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(iPinfo);
        }

        // GET: IPinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iPinfo = await _context.IPinfo.SingleOrDefaultAsync(m => m.ID == id);
            if (iPinfo == null)
            {
                return NotFound();
            }
            return View(iPinfo);
        }

        // POST: IPinfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IPAddress,countryName,countryCode,regionName,cityName,zipCode,timeZone,longitude,latitude")] IPinfo iPinfo)
        {
            if (id != iPinfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iPinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IPinfoExists(iPinfo.ID))
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
            return View(iPinfo);
        }

        // GET: IPinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iPinfo = await _context.IPinfo
                .SingleOrDefaultAsync(m => m.ID == id);
            if (iPinfo == null)
            {
                return NotFound();
            }

            return View(iPinfo);
        }

        // POST: IPinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iPinfo = await _context.IPinfo.SingleOrDefaultAsync(m => m.ID == id);
            _context.IPinfo.Remove(iPinfo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool IPinfoExists(int id)
        {
            return _context.IPinfo.Any(e => e.ID == id);
        }
    }
}
