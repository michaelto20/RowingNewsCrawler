using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewsWebCrawler.Data;

namespace NewsWebCrawler.Controllers
{
    public class NewsArticlesController : Controller
    {
        private DataModel db = new DataModel();

        // GET: NewsArticles
        public ActionResult Index()
        {
            return View(db.NewsArticles.ToList());
        }

        // GET: NewsArticles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            if (newsArticle == null)
            {
                return HttpNotFound();
            }
            return View(newsArticle);
        }

        // GET: NewsArticles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsArticles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,URL,Title,Team")] NewsArticle newsArticle)
        {
            if (ModelState.IsValid)
            {
                db.NewsArticles.Add(newsArticle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsArticle);
        }

        // GET: NewsArticles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            if (newsArticle == null)
            {
                return HttpNotFound();
            }
            return View(newsArticle);
        }

        // POST: NewsArticles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,URL,Title,Team")] NewsArticle newsArticle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsArticle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsArticle);
        }

        // GET: NewsArticles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            if (newsArticle == null)
            {
                return HttpNotFound();
            }
            return View(newsArticle);
        }

        // POST: NewsArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            db.NewsArticles.Remove(newsArticle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
