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
        [Display(Name ="Race")]
        [ForeignKey("Race"), Column(Order = 0)]
        public int RaceId { get; set; }

        [Display(Name = "Regatta")]
        [ForeignKey("Race"), Column(Order = 1)]
        public string Regatta { get; set; }

        public virtual Race Race { get; set; }

    }
}