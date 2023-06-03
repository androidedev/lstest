using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ncorerazor.Data;
using ncorerazor.models;

namespace ncorerazor.Pages
{
    public class EditModel : PageModel
    {
        private readonly ncorerazor.Data.ApplicationDbContext _context;

        public EditModel(ncorerazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Languajes Languajes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Languajes == null)
            {
                return NotFound();
            }

            var languajes =  await _context.Languajes.FirstOrDefaultAsync(m => m.Id == id);
            if (languajes == null)
            {
                return NotFound();
            }
            Languajes = languajes;
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

            _context.Attach(Languajes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguajesExists(Languajes.Id))
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

        private bool LanguajesExists(int id)
        {
          return (_context.Languajes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
