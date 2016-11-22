using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsWebCrawler.Data
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Team { get; set; }

        [Required]
        public List<RaceResult> RaceResults { get; set; }

        public class RaceResult
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public string Team { get; set; }

            [Required]
            public TimeSpan Time { get; set; }

            [Required]
            public string BoatClass { get; set; }
        }
            
    }

}