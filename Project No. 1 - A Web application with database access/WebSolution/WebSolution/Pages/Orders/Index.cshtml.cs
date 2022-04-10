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
    public class IndexModel : PageModel
    {
        private readonly WebSolution.Data.MySolutionContext _context;

        public IndexModel(WebSolution.Data.MySolutionContext context)
        {
            _context = context;
        }

        public IList<ORDERS> ORDERS { get;set; }

        public async Task OnGetAsync()
        {
            ORDERS = await _context.ORDERS
                .Include(o => o.MOVIES).ToListAsync();
        }
    }
}
