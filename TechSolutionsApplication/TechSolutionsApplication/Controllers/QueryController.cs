using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechSolutionsApplication.Models;
using Microsoft.AspNet.Identity;

namespace TechSolutionsApplication.Controllers
{
    public class QueryController : Controller
    {
        Database1Entities1 db = new Database1Entities1();
        // GET: Query

        public ActionResult QueryListForAdmin()
        {
            var queryListObj = from k in db.Queries select k;
            
            return PartialView(queryListObj.ToList());
        }


        public ActionResult ShowQueryListPartial(String searchStr)
        {
            ViewBag.Categories = "All";
            var queryListObj = from k in db.Queries select k;

            if (!String.IsNullOrEmpty(searchStr))
            {
                String[] str = searchStr.Split(',');
                if (str[0].Equals("Catid"))
                {
                    int cid = int.Parse(str[1]);
                    ViewBag.Categories = str[2];
                    queryListObj = from k in db.Queries
                                   where k.CatId == cid
                                   select k;
                }
                else
                {
                   queryListObj = queryListObj.Where(s => s.Title.Contains(searchStr));
                }
            }
            

            return PartialView(queryListObj.ToList());
        }
        
        [Authorize(Roles ="User")]
        public ActionResult AddQueryPartial()
        {
            var categoriesList = db.Categories.ToList();
            if (categoriesList != null)
            {
                ViewBag.CategoriesList = categoriesList;
            }

            Query queryObj = new Query();
            return View(queryObj);
        }

        [HttpPost]
        public ActionResult AddQueryPartial(Query queryObj)
        {
            try
            {
                // TODO: Add insert logic here
                Query q = new Query();
                q.QStatus = "New";
                q.QDatetime = DateTime.Now;
                q.CatId = queryObj.CatId;
                q.Ques = queryObj.Ques;
                q.Title = queryObj.Title;
                q.LikeCount = 0;
                q.AnsCount = 0;
                q.CommentCount = 0;
                q.UserName = User.Identity.Name;

                db.Queries.Add(q);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetQusAndAns(int id)
        {
            Query q = (from k in db.Queries
                       where k.Id == id
                       select k).FirstOrDefault();
            
            Session["QId"] = q.Id;
            return View(q);
        }


        // Show Answers By Qustions
        public ActionResult ShowAnswerListByQusPartial(int QId)
        {
            var queryListObj = from k in db.Answers
                               where k.QId ==  QId
                               select k;
            return PartialView(queryListObj.ToList());
        }


        // Create Method For Answers
        public ActionResult AnswersCreate()
        {
            Answer obj = new Answer();
            return PartialView(obj);
        }

        [HttpPost]
        public ActionResult AnswersCreate(Answer obj)
        {
            try
            {
                // TODO: Add insert logic here
                Answer q = new Answer();
                q.Ans = obj.Ans;
                q.DateTiime = DateTime.Now;
                q.UId = 1;
                q.QId = int.Parse(Session["QId"].ToString());
                q.UserName = User.Identity.Name;
                db.Answers.Add(q);
                db.SaveChanges();
                AnsIncrementDecreament(q.QId, "inc");

                return PartialView();
            }
            catch
            {
                return PartialView();
            }
        }

        // Show Answers By Qustions
        public ActionResult ShowCommentListByQusPartial(int QId)
        {
            var queryListObj = from k in db.Comments
                               where k.QId == QId
                               select k;
            return PartialView(queryListObj.ToList());
        }

        // Create Method For Answers
        public ActionResult CommentCreate()
        {
            Comment obj = new Comment();
            return PartialView(obj);
        }

        [HttpPost]
        public ActionResult CommentCreate(Comment obj)
        {
            try
            {
                // TODO: Add insert logic here
                Comment q = new Comment();
                q.Comment1 = obj.Comment1;
                q.DateTiime = DateTime.Now;
                q.UId = 1;
                q.UserName = User.Identity.Name;
                q.QId = int.Parse(Session["QId"].ToString());
                db.Comments.Add(q);
                db.SaveChanges();
                CommentIncrementDecreament(q.QId,"inc");

                return PartialView();
            }
            catch
            {
                return PartialView();
            }
        }

        public void CommentIncrementDecreament(int? qid,String action)
        {
            Query q = (from k in db.Queries
                       where k.Id == qid
                       select k).FirstOrDefault();
            if (action.Equals("inc"))
            {
                q.CommentCount = q.CommentCount + 1;
            }

            if (action.Equals("dec"))
            {
                q.CommentCount = q.CommentCount - 1;
            }

            db.SaveChanges();
        }

        public void AnsIncrementDecreament(int? qid, String action)
        {
            Query q = (from k in db.Queries
                       where k.Id == qid
                       select k).FirstOrDefault();
            if (action.Equals("inc"))
            {
                q.AnsCount = q.AnsCount + 1;
            }

            if (action.Equals("dec"))
            {
                q.AnsCount = q.AnsCount - 1;
            }

            db.SaveChanges();
        }

    }
}