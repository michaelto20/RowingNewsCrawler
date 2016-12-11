using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsWebCrawler.Data
{
    public class User
    {
        [Key]
        [Required] //TODO: Remove this
        public string Id { get; set; }

        //[Key,Column(Order = 0)]
        [Required] // TODO: Remove this
        public string FavTeam { get; set; }
    }
}