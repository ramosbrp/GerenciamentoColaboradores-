using Microsoft.EntityFrameworkCore;
using GerenciamentoColaboradores.Models;

namespace GerenciamentoColaboradores.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
    }
}
