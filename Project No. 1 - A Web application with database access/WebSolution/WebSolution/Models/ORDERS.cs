using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSolution.Models
{
    public class ORDERS
    {
        [Key]
        [Display(Name = "Order ID")]
        public int ORDER_ID { get; set; }
        [Display(Name = "Rental Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[ConcurrencyCheck]
        public System.DateTime RENTAL_DATE { get; set; }
        [Display(Name = "Return Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[ConcurrencyCheck]
        public System.DateTime RETURN_DATE { get; set; }
        [Display(Name = "Movie ID")]
        //[ConcurrencyCheck]
        public int MOVIE_ID { get; set; }
        [Display(Name = "Net Amount")]
        //[ConcurrencyCheck]
        public decimal NET_AMOUNT { get; set; }
        [Display(Name = "Discount")]
        //[ConcurrencyCheck]
        public Nullable<decimal> DISCOUNT { get; set; }
        [Display(Name = "Gross Amount")]
        //[ConcurrencyCheck]
        public decimal GROSS_AMOUNT { get; set; }

        [ForeignKey("MOVIE_ID")]
        [Display(Name = "Movie ID")]
        public MOVIES MOVIES { get; set; }
    }
}
