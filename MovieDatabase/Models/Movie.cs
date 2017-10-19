using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Models
{
    public class Movie
    {
        [Required(ErrorMessage = "Missing ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "We need a name for this")]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string IMDBurl { get; set; }
        public string rating { get; set; }
        public string director { get; set; }
        public int releaseYear { get; set; }
        public string plot { get; set; }
        public string thumbnail { get; set; }
        public string trailer { get; set; }
        public string userID { get; set; }
        public bool watched { get; set; }
    }
}