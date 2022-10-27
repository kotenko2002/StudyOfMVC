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
    }
}
