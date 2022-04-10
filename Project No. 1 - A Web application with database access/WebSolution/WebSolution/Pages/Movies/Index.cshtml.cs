using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebSolution.Data;
using WebSolution.Models;

namespace WebSolution.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly WebSolution.Data.MySolutionContext _context;

        public IndexModel(WebSolution.Data.MySolutionContext context)
        {
            _context = context;
        }

        public string TitleFilter { get; set; }
        public string GenreFilter { get; set; }
        public string RatingFilter { get; set; }
        public DateTime FromFilter { get; set; }
        public DateTime ToFilter { get; set; }

        public IList<MOVIES> MOVIES { get;set; }

        public async Task OnGetAsync(string titleValue, string genreValue, string ratingValue, DateTime fromValue, DateTime toValue)
        {

            TitleFilter = titleValue;
            GenreFilter = genreValue;
            RatingFilter = ratingValue;
            FromFilter = fromValue;
            ToFilter = toValue;
            //Convert.ToDecimal(ratingValue);

            IQueryable<MOVIES> moviesIQ = from s in _context.MOVIES
                                             select s;
            if (!String.IsNullOrEmpty(titleValue))
                moviesIQ = moviesIQ.Where(s => s.MOVIE_TITLE.Contains(titleValue));
            if (!String.IsNullOrEmpty(genreValue))
                moviesIQ = moviesIQ.Where(s => s.GENRE.Contains(genreValue));
            if (Convert.ToDecimal(ratingValue) > 0)
                moviesIQ = moviesIQ.Where(s => s.RATING >= Convert.ToDecimal(ratingValue));
            if (fromValue.Year > 1800 && fromValue.Year < 2100)
                moviesIQ = moviesIQ.Where(s => s.RELEASE_DATE >= fromValue);
            if (toValue.Year > 1800 && toValue.Year < 2100)
                moviesIQ = moviesIQ.Where(s => s.RELEASE_DATE <= toValue);

            MOVIES = await moviesIQ.AsNoTracking().ToListAsync();
        }
    }
}
