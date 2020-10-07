using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Healthy_Me.Data;
using Healthy_Me.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthy_Me.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext Context)
        {
            _context = Context;
        }
        // GET: Admin
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var admin = _context.Admins.Where(a => a.IdentityUserId ==
            userId).SingleOrDefault();

            if (admin == null)
            {

                return RedirectToAction("Create");

            }
            return View("Details", admin);
        }

        // GET: Admin/Details/5
        public ActionResult Details(Admin admin)
        {
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        

        [HttpPost("FileUpload")]
        public async Task<IActionResult> Create(List<IFormFile> files)
        {
            var size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // full path to file in temp location
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), formFile.FileName);
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Ok(new { count = files.Count, size, filePaths });
        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> Edit(List<IFormFile> files)
        {
            var size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // full path to file in temp location
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), formFile.FileName);
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Ok(new { count = files.Count, size, filePaths });
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            Admin admin = new Admin();
            return View(admin);
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                admin.IdentityUserId = userId;
                _context.Add(admin);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }


            return RedirectToAction("Details");
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            var admin = _context.Admins.SingleOrDefault(a => a.Id == id);
            if (id == null)
            {
                return NotFound();
            }


            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }







        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin admin)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var adminFromDb = _context.Customers.Where(a => a.IdentityUserId == userId).SingleOrDefault();
                adminFromDb.firstName = admin.firstName;
                adminFromDb.lastName = admin.lastName;
                



                _context.Update(adminFromDb);
                _context.SaveChanges();
                return RedirectToAction("Details", adminFromDb);



            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
