using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookTrackingApp_VishalChavda.Data;
using BookTrackingApp_VishalChavda.Models;

namespace BookTrackingApp_VishalChavda.Pages.Admin.Books
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
            ViewData["CatItems"] = new SelectList(_context.Categorys, "NameToken", "NameToken");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            ViewData["CatItems"] = new SelectList(_context.Categorys, "NameToken", "NameToken");

            return RedirectToPage("./Index");
        }
    }
}
