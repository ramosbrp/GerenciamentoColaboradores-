using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GerenciamentoColaboradores.Data;
using GerenciamentoColaboradores.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public ColaboradorViewModel ViewModel { get; set; } = new ColaboradorViewModel();
        public async Task OnGetAsync()
        {
            ViewModel = new ColaboradorViewModel
            {
                Colaboradores = await _context.Colaboradores.Include(c => c.Cargo).ToListAsync(),
                Cargos = await _context.Cargos.ToListAsync()
            };
        }

        public async Task<IActionResult> OnPostCreateAsync([FromForm] Colaborador colaborador)
        {
            if (colaborador.Id != 0 && !ModelState.IsValid)
            {
                // Carrega novamente os cargos para a página em caso de erro
                ViewData["Cargos"] = new SelectList(await _context.Cargos.ToListAsync(), "Id", "Nome", colaborador.CargoId);
                return Page();
            }

            if (colaborador.Id > 0) // Checa se o ID existe
            {
                var existingColaborador = await _context.Colaboradores.FindAsync(colaborador.Id);
                if (existingColaborador != null)
                {
                    // Atualiza propriedades do colaborador existente
                    existingColaborador.Nome = colaborador.Nome;
                    existingColaborador.Email = colaborador.Email;
                    existingColaborador.Telefone = colaborador.Telefone;
                    existingColaborador.CargoId = colaborador.CargoId;
                    // Outras propriedades conforme necessário
                }
                else
                {
                    // Handle caso o colaborador não seja encontrado, opcional
                    TempData["Error"] = "Colaborador não encontrado.";
                    return RedirectToPage();
                }
            }
            else
            {
                // Adiciona um novo colaborador
                _context.Colaboradores.Add(colaborador);
            }

            await _context.SaveChangesAsync();

            // Carrega o Cargo associado se necessário
            _context.Entry(colaborador).Reference(c => c.Cargo).Load();

            TempData["Message"] = "Colaborador salvo com sucesso.";
            return RedirectToPage();
        }

        public void OnPost()
        {
            Console.WriteLine("POST chamado");
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
