using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsWebCrawler.Data;

namespace NewsWebCrawler.Models
{
    public class TeamViewModel
    {
        public List<Result> TeamResults { get; set; } = new List<Result>();
        public List<NewsArticle> TeamArticles { get; set; } = new List<NewsArticle>();
    }
}