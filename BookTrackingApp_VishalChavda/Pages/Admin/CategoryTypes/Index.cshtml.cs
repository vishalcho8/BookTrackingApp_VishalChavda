using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookTrackingApp_VishalChavda.Data;
using BookTrackingApp_VishalChavda.Models;

namespace BookTrackingApp_VishalChavda.Pages.Admin.CategoryTypes
{
    public class IndexModel : PageModel
    {
        private readonly BookTrackingApp_VishalChavda.Data.BookTrackingContext _context;

        public IndexModel(BookTrackingApp_VishalChavda.Data.BookTrackingContext context)
        {
            _context = context;
        }

        public IList<CategoryType> CategoryType { get;set; }

        public async Task OnGetAsync()
        {
            CategoryType = await _context.CategoryTypes.ToListAsync();
        }
    }
}
