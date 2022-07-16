using BloodBanK.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBanK.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            using (BBMSContext db = new BBMSContext())
            {
                TempData["Donor"] = db.users.ToList();

            }
            using (BBMSContext db = new BBMSContext())
            {
                TempData["BloodReq"] = db.reqs.ToList();

            }
            TempData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
       /* public IActionResult Add()
        {

            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public IActionResult Add(BloodReq st)
        {
            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;
            st.UserName = HttpContext.Session.GetString("UserName");
            using (BBMSContext db = new BBMSContext())
            {
                db.Reqs.Add(st);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["AddMsg"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["AddMsg"] = "0";
                }
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;

            BloodReq ss = new BloodReq();
            using (BBMSContext db = new BBMSContext())
            {
                ss = db.Reqs.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult Edit(BloodReq s)
        {
            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;
            using (BBMSContext db = new BBMSContext())
            {
                var Result = db.Reqs.Find(s.Id);
                Result.Name = s.Name;
                Result.BloodGroup = s.BloodGroup;
                Result.State = s.State;
                Result.PhoneNo = s.PhoneNo;
                Result.City = s.City;
                Result.UserName = HttpContext.Session.GetString("UserName");
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
            return RedirectToAction("Index", "User");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            BloodReq ss = new BloodReq();
            using (BBMSContext db = new BBMSContext())
            {
                ss = db.Reqs.Where(x => x.Id == id).FirstOrDefault();
                db.Reqs.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("Index", "User");
        }*/
    }
}
