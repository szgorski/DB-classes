using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebSolution.Data;
using WebSolution.Models;

namespace WebSolution.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly WebSolution.Data.MySolutionContext _context;

        public DeleteModel(WebSolution.Data.MySolutionContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ORDERS = await _context.ORDERS.FindAsync(id);

            if (ORDERS != null)
            {
                _context.ORDERS.Remove(ORDERS);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
