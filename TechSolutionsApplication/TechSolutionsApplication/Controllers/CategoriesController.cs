using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechSolutionsApplication.Models;
namespace TechSolutionsApplication.Controllers
{
    public class CategoriesController : Controller
    {
        Database1Entities1 db = new Database1Entities1();
        // GET: Categories
        public ActionResult CategoriesListPartial()
        {
            var categoriesList = from k in db.Categories select k;
            return PartialView(categoriesList.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CategoriesList()
        {
            var list = from k in db.Categories select k;
            return View(list.ToList());
        }
        
        // GET: Categories/Create
        [Authorize(Roles = "Admin")]
        public ActionResult CategoriesCreate()
        {
            Category c = new Category();
            return View(c);
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult CategoriesCreate(Category c)
        {
            try
            {
                // TODO: Add insert logic here
                db.Categories.Add(c);
                db.SaveChanges();
                return RedirectToAction("CategoriesList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult CategoriesEdit(int id)
        {
            return View();
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult CategoriesEdit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult CategoriesDelete(int id)
        {
            Category c = (from k in db.Categories
                          where k.Id == id
                          select k).FirstOrDefault();
            return PartialView(c);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult CategoriesDelete(int id, Category c)
        {
            try
            {
                // TODO: Add delete logic here
                Category ca = (from k in db.Categories
                              where k.Id == c.Id
                              select k).FirstOrDefault();

                db.Categories.Remove(ca);
                db.SaveChanges();
                return PartialView();
            }
            catch
            {
                return PartialView();
            }
        }
    }
}
