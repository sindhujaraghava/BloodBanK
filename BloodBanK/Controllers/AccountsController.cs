using BloodBanK.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBanK.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User lg)
        {
            using (BBMSContext db = new BBMSContext())
            {
                var users = db.users.Where(x => x.UserName == lg.UserName && x.Password == lg.Password);
                if (users.Count() > 0)
                {
                    TempData["msg"] = "1";
                    var user = users.FirstOrDefault();

                    HttpContext.Session.SetInt32("Role", user.RoleId);
                    HttpContext.Session.SetString("Name", user.FirstName + " " + user.LastName);
                    HttpContext.Session.SetString("UserName", user.UserName);
                    if (user.RoleId == 101)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    if (user.RoleId == 102)
                    {
                        return RedirectToAction("Index", "User");
                    }


                }
                else
                {
                    TempData["msg"] = "0";
                }
            }
            return View();
        }

        public IActionResult Signup()
        {
            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public IActionResult Signup(User um)
        {
            um.RoleId = 102;
            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;
            using (BBMSContext db = new BBMSContext())
            {
                db.users.Add(um);
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

            return RedirectToAction("Login", "Accounts");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Accounts");
        }

    }
}
