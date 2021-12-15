using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookTrackingApp_VishalChavda.Data;
using BookTrackingApp_VishalChavda.Models;

namespace BookTrackingApp_VishalChavda.Pages.Admin.Categorys
{
    public class EditModel : PageModel
    {
        private readonly BookTrackingApp_VishalChavda.Data.BookTrackingContext _context;

        public EditModel(BookTrackingApp_VishalChavda.Data.BookTrackingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categorys.FirstOrDefaultAsync(m => m.NameToken == id);

            if (Category == null)
            {
                return NotFound();
            }
            ViewData["Type"] = new SelectList(_context.CategoryTypes, "Type", "Type");
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

            _context.Attach(Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Category.NameToken))
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

        private bool CategoryExists(string id)
        {
            return _context.Categorys.Any(e => e.NameToken == id);
        }
    }
}
