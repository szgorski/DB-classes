using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSolution.Data;
using WebSolution.Models;

namespace WebSolution.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly WebSolution.Data.MySolutionContext _context;

        public CreateModel(WebSolution.Data.MySolutionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ORDERS ORDERS { get; set; }
        public decimal discount = 0.25M;

        public IActionResult OnGet(int id)
        {
            ORDERS = new ORDERS();
            ORDERS.MOVIE_ID = id;
            ORDERS.MOVIES = _context.MOVIES.Find(ORDERS.MOVIE_ID);
            ORDERS.RENTAL_DATE = DateTime.Now;
            if (DateTime.Now.AddYears(-5) >= ORDERS.MOVIES.RELEASE_DATE)
            {
                ORDERS.RETURN_DATE = DateTime.Now.AddDays(7);
                ORDERS.DISCOUNT = discount;
                ORDERS.GROSS_AMOUNT = ORDERS.MOVIES.PRICE * (1M - discount) * 1.23M; 
            }
            else
            {
                ORDERS.RETURN_DATE = DateTime.Now.AddDays(3);
                ORDERS.DISCOUNT = 0M;
                ORDERS.GROSS_AMOUNT = ORDERS.MOVIES.PRICE * 1.23M;

            }
            ORDERS.NET_AMOUNT = ORDERS.MOVIES.PRICE;
            _context.ORDERS.Add(ORDERS);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
