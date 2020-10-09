﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Healthy_Me.Data;
using Healthy_Me.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Healthy_Me.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
           
            _context = context;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            
            if (customer == null)
            {

                return RedirectToAction("Create");
                
            }
            return View("Details", customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(Customer customer)
        {
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();

            return View(customer);
        }
    

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {

            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Create", "NutritionProfiles");
                
            }
            
            
            return RedirectToAction("Details");
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (id == null)
            {
                return NotFound();
            }


            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customerFromDb = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
                customerFromDb.firstName = customer.firstName;
                customerFromDb.lastName = customer.lastName;
                customerFromDb.goal = customer.goal;
                customerFromDb.age = customer.age;
                customerFromDb.streetAddress = customer.streetAddress;
                customerFromDb.city = customer.city;
                customerFromDb.state = customer.state;
                customerFromDb.zipCode = customer.zipCode;




                _context.Update(customerFromDb);
                _context.SaveChanges();
                return RedirectToAction("Details", customerFromDb);



            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
