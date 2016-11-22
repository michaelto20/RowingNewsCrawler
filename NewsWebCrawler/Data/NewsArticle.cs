using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsWebCrawler.Data
{
    public class NewsArticle
    {
        [MaxLength(255)]
        [Required]
        public string URL { get; set; }

        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Team { get; set; }

        public NewsArticle()
        {

        }

    }
}