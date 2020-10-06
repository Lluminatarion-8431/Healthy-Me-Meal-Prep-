using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthy_Me.Controllers
{
    public class NutritionProfileController : Controller
    {
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
            return View();
        }

        // POST: NutritionProfile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
