using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsWebCrawler.Models
{
    public class NewsArticle
    {
        public int Id { get; set; }

        public string articleURL { get; set; }

        public string Title { get; set; }

        public string team { get; set; }

        public string summary { get; set; }

        
        public NewsArticle(string articleURL, string subject, string team, string summary)
        {
            this.articleURL = articleURL;
            this.Title = subject;
            this.team = team;
            this.summary = summary;
        }
    }
}