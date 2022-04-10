using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSolution.Data;
using WebSolution.Models;

namespace WebSolution.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly WebSolution.Data.MySolutionContext _context;

        public EditModel(WebSolution.Data.MySolutionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ORDERS ORDERS { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ORDERS = await _context.ORDERS
                .Include(o => o.MOVIES).FirstOrDefaultAsync(m => m.ORDER_ID == id);

            if (ORDERS == null)
            {
                return NotFound();
            }
           ViewData["MOVIE_ID"] = new SelectList(_context.MOVIES, "MOVIE_ID", "MOVIE_ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ORDERS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORDERSExists(ORDERS.ORDER_ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ORDERSExists(int id)
        {
            return _context.ORDERS.Any(e => e.ORDER_ID == id);
        }
    }
}
