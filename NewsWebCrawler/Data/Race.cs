using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsWebCrawler.Data
{
    public class Race
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(Order = 0)]
//        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        public string Team { get; set; }

        [Required]
        [Key, Column(Order = 1)]
        public string Regatta { get; set; }
        
        // Navigation Properties
        public virtual ICollection<Result> Results { get; set; }

        public Race()
        {

        }
     
    }

}