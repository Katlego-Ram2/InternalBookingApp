using InternalBookingApp.Data;
using InternalBookingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternalBookingApp.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var resources = await _context.Resources.ToListAsync();
            return View(resources);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Resource resource)
        {
            if (ModelState.IsValid)
            {
                _context.Resources.Add(resource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var resource = await _context.Resources.FindAsync(id);
            if (resource == null) return NotFound();
            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Resource resource)
        {
            if (id != resource.ResourceId) return BadRequest();

            if (ModelState.IsValid)
            {
                _context.Update(resource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var resource = await _context.Resources.FindAsync(id);
            if (resource == null) return NotFound();
            return View(resource);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resource = await _context.Resources.FindAsync(id);
            _context.Resources.Remove(resource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var resource = await _context.Resources.FirstOrDefaultAsync(r => r.ResourceId == id);
            if (resource == null) return NotFound();
            return View(resource);
        }
    }
}
