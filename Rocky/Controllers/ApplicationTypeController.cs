using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Linq;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly AppDbContext _db;
        public ApplicationTypeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var list = _db.ApplicationType.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ApplicationType type)
        {
            _db.ApplicationType.Add(type);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var appType = _db.ApplicationType.Find(id);
            if(appType == null)
            {
                return NotFound();
            }

            return View(appType);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationType appType)
        {
            if (appType == null)
            {
                return NotFound();
            }

            _db.ApplicationType.Update(appType);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var appType = _db.ApplicationType.Find(id);
            if (appType == null)
            {
                return NotFound();
            }

            return View(appType);
        }

        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var appType = _db.ApplicationType.Find(id);
            if (appType == null)
            {
                return NotFound();
            }

            _db.ApplicationType.Remove(appType);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
