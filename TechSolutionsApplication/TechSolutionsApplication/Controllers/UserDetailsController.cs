using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechSolutionsApplication.Models;
namespace TechSolutionsApplication.Controllers
{
    public class UserDetailsController : Controller
    {
        Database1Entities1 db = new Database1Entities1();
        // GET: UserDetails/Details/5
        public ActionResult Details()
        {
            UserDetail u = (from k in db.UserDetails
                            where k.Email == User.Identity.Name.ToString()
                            select k).FirstOrDefault();
            return PartialView(u);
        }

        // GET: UserDetails/Create
        public ActionResult Create()
        {
            UserDetail ud = (from k in db.UserDetails
                             where k.Email == User.Identity.Name.ToString()
            select k).FirstOrDefault();
            return PartialView(ud);
        }

        // POST: UserDetails/Create
        [HttpPost]
        public ActionResult Create(UserDetail ud)
        {
            try
            {
                // TODO: Add insert logic here
                UserDetail u = (from k in db.UserDetails
                                where k.Email == ud.Email
                                select k).FirstOrDefault(); ;
                
                u.Name = ud.Name;
                u.Contact = ud.Contact;
                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            catch
            {
                return PartialView();
            }
        }

        public void createMethod(String email)
        {
            UserDetail us = new UserDetail();
            us.Email = email;
            db.UserDetails.Add(us);
            db.SaveChanges();
        }


        public ActionResult UserQusList()
        {
            UserDetail u = (from k in db.UserDetails
                            where k.Email == User.Identity.Name.ToString()
                            select k).FirstOrDefault();
            return PartialView(u);
        }

    }
}
