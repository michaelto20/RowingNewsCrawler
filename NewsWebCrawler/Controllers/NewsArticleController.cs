using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebCrawler.Controllers
{
    public class NewsArticleController : Controller
    {
        // GET: NewsArticle
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PickTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PickTeam(string team_pick)
        {
            ViewBag.Picked = "Thank you for selecting " + team_pick;
            return RedirectToAction("Index");
        }

        // GET: NewsArticle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsArticle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsArticle/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsArticle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsArticle/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: NewsArticle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsArticle/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
