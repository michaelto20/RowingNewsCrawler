using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsWebCrawler.Data;

namespace NewsWebCrawler.Models
{
    public class TeamViewModel
    {
        public List<Race> Races { get; set; } = new List<Race>();
        public List<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();
    }
}