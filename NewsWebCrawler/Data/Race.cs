using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsWebCrawler.Data
{
    public class Race
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Team { get; set; }

        [Required]
        public string Regatta { get; set; }
        
        // Navigation Properties
        public virtual ICollection<Result> Results { get; set; }

        public Race()
        {

        }
     
    }

}