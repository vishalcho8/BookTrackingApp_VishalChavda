using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookTrackingApp_VishalChavda.Data;
using BookTrackingApp_VishalChavda.Models;

namespace BookTrackingApp_VishalChavda.Pages.Admin.Categorys
{
    public class CreateModel : PageModel
    {
        private readonly BookTrackingApp_VishalChavda.Data.BookTrackingContext _context;

        public CreateModel(BookTrackingApp_VishalChavda.Data.BookTrackingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Type"] = new SelectList(_context.CategoryTypes, "Type", "Type");
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categorys.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
