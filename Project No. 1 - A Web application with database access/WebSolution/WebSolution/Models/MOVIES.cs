using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSolution.Models
{
    public class MOVIES
    {
        [Key]
        [Display(Name = "Movie ID")]
        public int MOVIE_ID { get; set; }
        [Display(Name = "Movie Title")]
        public string MOVIE_TITLE { get; set; }
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime RELEASE_DATE { get; set; }
        [Display(Name = "Price")]
        public decimal PRICE { get; set; }
        [Display(Name = "Rating")]
        public decimal RATING { get; set; }
        [Display(Name = "Genre")]
        public string GENRE { get; set; }

        public ICollection<ORDERS> ORDERS { get; set; }
    }
}
