using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsWebCrawler.Data
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string FavTeam { get; set; }
    }
}