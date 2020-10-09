using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Healthy_Me.Data;
using Healthy_Me.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthy_Me.Controllers
{
    public class NutritionProfilesController : Controller
    {
        public static HttpClient recipeAPI = new HttpClient();
        private readonly ApplicationDbContext _context;
        public NutritionProfilesController(ApplicationDbContext Context)
        {
            _context = Context;
        }

        // GET: NutritionProfile
        public ActionResult Index()
        {
            return View();
        }

        // GET: NutritionProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NutritionProfile/Create
        public ActionResult Create()
        {
            NutritionProfile nutritionProfile = new NutritionProfile();

            return View(nutritionProfile);
        }

        // POST: NutritionProfile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NutritionProfile nutritionProfile)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(address);


                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customer = _context.Customers.Where(c => c.IdentityUserId == userId).First();
                customer.nutritionProfile = nutritionProfile;
                _context.Customers.Update(customer);
                _context.SaveChanges();


                return RedirectToAction("Index", "Customers");

            }
            return View(nutritionProfile);
        }

        // GET: NutritionProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NutritionProfile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: NutritionProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NutritionProfile/Delete/5
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
