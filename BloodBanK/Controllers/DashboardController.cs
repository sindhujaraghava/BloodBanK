﻿using BloodBanK.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBanK.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            using (BBMSContext db = new BBMSContext())
            {
                TempData["Donor"] = db.users.ToList();

            }
            using (BBMSContext db = new BBMSContext())
            {
                TempData["BloodReq"] = db.Reqs.ToList();

            }
            return View();
        }
        
        public IActionResult Edit(String UserName)
        {
            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;

            User ss = new User();
            using (BBMSContext db = new BBMSContext())
            {
                ss = db.users.Find(UserName);
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult Edit(User s)
        {
            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;
            using (BBMSContext db = new BBMSContext())
            {
                var Result = db.users.Find(s.UserName);
                Result.FirstName = s.FirstName;
                Result.LastName = s.LastName;
                Result.BloodGroup = s.BloodGroup;
                Result.Age = s.Age;
                Result.ContactNumber = s.ContactNumber;
                Result.City = s.City;
                Result.State = s.State;
                Result.Area= s.Area;
                Result.Weight = s.Weight;
                Result.Gender = s.Gender;
                Result.Pincode= s.Pincode;
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["EditMsg"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["EditMsg"] = "0";
                }

            }
            return RedirectToAction("Index", "Dashboard");
        }


        [HttpGet]
        public IActionResult Delete(String  UserName)
        {
            User ss = new User();
            using (BBMSContext db = new BBMSContext())
            {
                ss = db.users.Where(x => x.UserName.Equals(UserName)).FirstOrDefault();
                db.users.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
