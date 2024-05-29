using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GerenciamentoColaboradores.Data;
using GerenciamentoColaboradores.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoColaboradores.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Colaborador> Colaboradores { get; set; }
        public IList<Cargo> Cargos { get; set; }

        public async Task OnGetAsync()
        {
            Colaboradores = await _context.Colaboradores.Include(c => c.Cargo).ToListAsync();
            Cargos = await _context.Cargos.ToListAsync();
        }

        public async Task<IActionResult> OnPostCreateAsync(Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Colaboradores.Add(colaborador);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(colaborador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
