using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ncorerazor.Data;
using ncorerazor.models;

namespace ncorerazor.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ncorerazor.Data.ApplicationDbContext _context;

        public DetailsModel(ncorerazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Languajes Languajes { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Languajes == null)
            {
                return NotFound();
            }

            var languajes = await _context.Languajes.FirstOrDefaultAsync(m => m.Id == id);
            if (languajes == null)
            {
                return NotFound();
            }
            else 
            {
                Languajes = languajes;
            }
            return Page();
        }
    }
}
