using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ncorerazor.Data;
using ncorerazor.models;

namespace ncorerazor.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ncorerazor.Data.ApplicationDbContext _context;

        public CreateModel(ncorerazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Languajes Languajes { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Languajes == null || Languajes == null)
            {
                return Page();
            }

            _context.Languajes.Add(Languajes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
