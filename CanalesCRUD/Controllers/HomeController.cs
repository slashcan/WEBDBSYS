using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanalesCRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = new List<UserAccount>();
            using (var db = new WEBDBSYSEntities())
            {
                //DISPLAY all USER ACCOUNTS
                list = db.UserAccount.ToList();
            }
                return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserAccount u)
        {
            using (var db = new WEBDBSYSEntities())
            {
                var newUser = new UserAccount();
                newUser.username = u.username;
                newUser.password = u.password;

                db.UserAccount.Add(newUser);
                db.SaveChanges();

                TempData["msg"] = $"Added {newUser.username} Successfully!";
            }
                //inig press nimo og CREATE button mo redirect siya 
                return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var u = new UserAccount();
            using (var db = new WEBDBSYSEntities())
            {
                u = db.UserAccount.Find(id);
            }

            return View(u);
        }

        [HttpPost]
        public ActionResult Update(UserAccount u)
        {
            using (var db = new WEBDBSYSEntities())
            {
                var newUser = db.UserAccount.Find(u.id);
                newUser.username = u.username;
                newUser.password = u.password;

                
                db.SaveChanges();

                TempData["msg"] = $"Updated {newUser.username} Successfully!";
            }
            //inig press nimo og CREATE button mo redirect siya 
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var u = new UserAccount();
            using (var db = new WEBDBSYSEntities())
            {
                u = db.UserAccount.Find(id);
                db.UserAccount.Remove(u);
                db.SaveChanges();

                TempData["msg"] = $"Deleted {u.username} Successfully!";
            }

            return RedirectToAction("Index");
        }

    }
}