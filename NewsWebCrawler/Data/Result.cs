using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsWebCrawler.Data
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        [Required]
        public string BoatClass { get; set; }

        // Navigation Properties
        public int RaceId { get; set; }

        [ForeignKey("RaceId")]
        public virtual Race Race { get; set; }

    }
}