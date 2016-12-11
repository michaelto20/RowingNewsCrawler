using NewsWebCrawler.Data;
using NewsWebCrawler.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Linq;

namespace NewsWebCrawler.Controllers
{
    [Authorize]
    public class NewsArticleController : Controller
    {
        // GET: NewsArticle
        
        public ActionResult Index()
        {
            //string url = @"http://www.gocrimson.com/sports/mcrew-hw/headlines-featured?feed=rss_2.0";
            ////string url = @"http://www.gohuskies.com/rss.aspx?path=mrow";
            
            //var teamVM = new TeamViewModel();
            //using (DataModel dm = new DataModel())
            //{
            //    User user = (User)dm.Users.FirstOrDefault(u => u.Id.Equals(System.Web.HttpContext.Current.User.Identity.Name));
            //    if (user != null)
            //    {
            //        teamVM.NewsArticles.AddRange(CrawlRss(url, user.FavTeam));
            //        foreach (var res in dm.Race.Include("Results"))
            //        {
            //            if (res.Team == user.FavTeam)
            //            {
            //                teamVM.Races.Add(res);
            //            }
            //        }
            //    }

            //}
            return View();
        }

        [HttpPost]
        public ActionResult Index(string picked_team)
        {
            string url = "";
            //string url = @"http://www.gocrimson.com/sports/mcrew-hw/headlines-featured?feed=rss_2.0";
            //string url = @"http://www.gohuskies.com/rss.aspx?path=mrow";
            switch (picked_team)
            {
                case "Harvard":
                    url = @"http://www.gocrimson.com/sports/mcrew-hw/headlines-featured?feed=rss_2.0";
                    break;
                default:
                    break;
            }

            var teamVM = new TeamViewModel();
            using (DataModel dm = new DataModel())
            {
                //if user exists update with new team preference
                User currentUser = (User)dm.Users.FirstOrDefault(u => u.Id.Equals(System.Web.HttpContext.Current.User.Identity.Name));
                if (currentUser != null)
                {
                    teamVM.NewsArticles.AddRange(CrawlRss(url, currentUser.FavTeam));
                    foreach (var res in dm.Race.Include("Results"))
                    {
                        if (res.Team == currentUser.FavTeam)
                        {
                            teamVM.Races.Add(res);
                        }
                    }

                    //remove previous preference from DB and update with new preference
                    dm.Users.Remove(currentUser);
                    currentUser.FavTeam = picked_team;
                    dm.Users.Add(currentUser);
                }
                else
                {
                    // if user hasn't ever picked a favorite team, add it to the DB
                    currentUser = new User();
                    currentUser.FavTeam = picked_team;
                    currentUser.Id = System.Web.HttpContext.Current.User.Identity.Name;

                    dm.Users.Add(currentUser);
                    dm.SaveChanges();


                }
                teamVM.NewsArticles.AddRange(CrawlRss(url, currentUser.FavTeam));
            }
            
            return Json(teamVM);
        }

        //public ActionResult PickTeam()
        //{
        //    ViewBag.IsTeamPicked = false;
        //    using (DataModel dm = new DataModel())
        //    {
        //        string userName = System.Web.HttpContext.Current.User.Identity.Name;
        //        User prevProfile = (User)dm.Users.FirstOrDefault(u => u.Id.Equals(userName));
        //        if (prevProfile != null)
        //        {
        //            ViewBag.IsTeamPicked = true;
        //        }
        //    }

        //    return View(ViewBag);
        //}

        //[HttpPost]
        //public ActionResult PickTeam(string team_pick)
        //{
        //    User user = new User();
        //    user.FavTeam = team_pick;
        //    user.Id = System.Web.HttpContext.Current.User.Identity.Name;
        //    using (DataModel dm = new DataModel())
        //    {
        //        User prevProfile = (User)dm.Users.FirstOrDefault(u => u.Id.Equals(user.Id));
        //        if (prevProfile != null)
        //        {
        //            dm.Users.Remove(prevProfile);
        //        }

        //        dm.Users.Add(user);
        //        dm.SaveChanges();

        //    }
        //    ViewBag.Picked = "Thank you for selecting " + team_pick;
        //    return RedirectToAction("Index");
        //}

        private List<NewsArticle> CrawlRss(string url, string team)
        {
            List<NewsArticle> newsArticles = new List<NewsArticle>();
            string subject = "";
            string summary = "";
            string articleURL = "";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                subject = item.Title.Text;
                summary = item.Summary.Text;
                articleURL = item.Id;
                NewsArticle article = new NewsArticle(articleURL, subject, team, summary);
                newsArticles.Add(article);
            }
            
            return newsArticles;
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
