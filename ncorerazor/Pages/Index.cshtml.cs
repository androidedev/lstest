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
    public class IndexModel : PageModel
    {
        private readonly ncorerazor.Data.ApplicationDbContext _context;

        public IndexModel(ncorerazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Languajes> Languajes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Languajes != null)
            {
                Languajes = await _context.Languajes.ToListAsync();
            }
        }
    }
}
