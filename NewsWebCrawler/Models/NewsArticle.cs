using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsWebCrawler.Models
{
    public class NewsArticle
    {
        public string URL { get; set; }

        public string Title { get; set; }

        public string Team { get; set; }

        public string Abstract { get; set; }

        public NewsArticle()
        {

        }

        public NewsArticle(string url, string title, string team, string summary)
        {
            this.URL = url;
            this.Title = title;
            this.Team = team;
            this.Abstract = summary;
        }
    }
}
