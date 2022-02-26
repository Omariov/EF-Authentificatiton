#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace test.Pages.Admin
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly test.Pages.Admin.EtudianrDbContexte _context;

        public IndexModel(test.Pages.Admin.EtudianrDbContexte context)
        {
            _context = context;
        }

        public IList<Etudiant> Etudiant { get;set; }

        public async Task OnGetAsync()
        {
            Etudiant = await _context.etudiants.ToListAsync();
        }
    }
}
