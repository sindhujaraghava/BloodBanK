using BloodBanK.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBanK.Controllers
{
    public class SlotController : Controller
    {
        public IActionResult Index()
        {
            using (BBMSContext db = new BBMSContext())
            {
                TempData["Slots"] = db.slots.ToList();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var list = new List<string>();
            using (BBMSContext db = new BBMSContext())
            { 
                list= db.hospitals.Select(x => x.HospitalName).ToList();
                ViewBag.list = list;
            }
                return View();
        }

        [HttpPost]
        public IActionResult Add(Slot s)
        {
            s.SlotId = Guid.NewGuid();
            using (BBMSContext db = new BBMSContext())
            {
                db.slots.Add(s);
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

            return RedirectToAction("Index", "Slot");
        }

        [HttpGet]
        public IActionResult Edit(Guid SlotId)
        {
            var list = new List<string>();
            Slot s = new Slot();
            using (BBMSContext db = new BBMSContext())
            {
                list = db.hospitals.Select(x => x.HospitalName).ToList();
                ViewBag.list = list;
                s = db.slots.Find(SlotId);
            }
            return View(s);
        }

        [HttpPost]
        public IActionResult Edit(Slot s)
        {
            using (BBMSContext db = new BBMSContext())
            {
                var Result = db.slots.Find(s.SlotId);
                Result.HospitalName = s.HospitalName;
                Result.SlotTime = s.SlotTime;
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
            return RedirectToAction("Index", "Slot");
        }

        [HttpGet]
        public IActionResult Delete(Guid SlotId)
        {
            Slot s = new Slot();
            using (BBMSContext db = new BBMSContext())
            {
                s = db.slots.Find(SlotId);
                db.slots.Remove(s);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("Index", "Slot");
        }
    }
}
