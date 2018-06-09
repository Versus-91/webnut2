using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace DataSystem.Controllers
{

    public class FeedbackController : Controller
    {
        private readonly WebNutContext _context;

        public FeedbackController(WebNutContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "dataentry")]

        public async Task<IActionResult> Index(string nmrid)
        {
            if (nmrid == null)
            {
                return NotFound("id not passed");
            }
            var item = await _context.Nmr.Where(m => m.Nmrid.Equals(nmrid)).SingleOrDefaultAsync();
            if (item == null)
            {
                return NotFound();
            }
            var model = new Feedback();
            model.Nmrid = item.Nmrid;
            model.items = _context.Feedback.Where(m => m.Nmrid.Equals(nmrid)).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "dataentry")]
        public async Task<IActionResult> Create([Bind("Nmrid,Problem")] Feedback item)
        {
            if (ModelState.IsValid)
            {
                item.Initiator = User.Identity.Name;
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { nmrid = item.Nmrid });
            }
            return View(item);
        }

        [Authorize(Roles = "dataentry")]
        public async Task<IActionResult> Edit(int id)
        {


            var item = await _context.Feedback.SingleOrDefaultAsync(m => m.Id == id && m.Initiator.Equals(User.Identity.Name));
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "dataentry")]
        public async Task<IActionResult> Edit(int id, [Bind] Feedback item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var model = _context.Feedback.Where(m => m.Id.Equals(id)).SingleOrDefault();
                try
                {
                    model.Problem = item.Problem;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistrictsExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { nmrid = model.Nmrid });
            }
            return View(item);
        }

        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> res(int id)
        {


            var item = await _context.Feedback.SingleOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> res(int id, [Bind] Feedback item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var model = _context.Feedback.Where(m => m.Id.Equals(id)).SingleOrDefault();
                try
                {
                    model.Respondent = User.Identity.Name;
                    model.Respose = item.Respose;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistrictsExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("reports","nmr", new { nmrid = model.Nmrid });
            }
            return View(item);
        }

        // GET: Districts/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = _context.Feedback.Where(m => m.Initiator.Equals(User.Identity.Name) && m.Id == id).SingleOrDefault();

            if (item == null)
            {
                return NotFound();
            }
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { nmrid = item.Nmrid });
        }

        private bool DistrictsExists(int id)
        {
            return _context.Feedback.Any(e => e.Id == id);
        }
    }
}
