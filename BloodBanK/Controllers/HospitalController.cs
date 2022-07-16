using BloodBanK.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBanK.Controllers
{
    public class HospitalController : Controller
    {
        public IActionResult Index()
        {
            using (BBMSContext db = new BBMSContext())
            {
                TempData["Hospitals"] = db.hospitals.ToList();
            }

            return View();
        }
        
        [HttpGet]
        public IActionResult Add() { 
            return View();
        }

        [HttpPost]
        public IActionResult Add(Hospital h) {
            using (BBMSContext db = new BBMSContext())
            {
                db.hospitals.Add(h);
                if (db.SaveChanges() > 0)
                {
                    TempData["status"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["status"] = "0";
                }
            }

            return RedirectToAction("Index", "Hospital");
        }

        [HttpGet]
        public IActionResult Edit(String HospitalName) {
            Hospital h = new Hospital();
            using (BBMSContext db = new BBMSContext())
            {
                h = db.hospitals.Find(HospitalName);
            }
            return View(h);
        }

        [HttpPost]
        public IActionResult Edit(Hospital h) {
            using (BBMSContext db = new BBMSContext())
            {
                var Result = db.hospitals.Find(h.HospitalName);
                Result.City = h.City;
                Result.Area = h.Area;
                Result.State = h.State;
                Result.Pincode = h.Pincode;
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
            return RedirectToAction("Index", "Hospital");
        }

        [HttpGet]
        public IActionResult Delete(string HospitalName) {
            Hospital h = new Hospital();
            using (BBMSContext db = new BBMSContext())
            {
                h = db.hospitals.Find(HospitalName);
                db.hospitals.Remove(h);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("Index", "Hospital");
        }

    }
}
