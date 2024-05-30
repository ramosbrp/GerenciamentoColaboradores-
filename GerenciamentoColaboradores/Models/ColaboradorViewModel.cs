using GerenciamentoColaboradores.Models;

namespace GerenciamentoColaboradores.Models
{
    public class ColaboradorViewModel
    {
        public Colaborador Colaborador { get; set; } = new Colaborador();
        public IList<Colaborador> Colaboradores { get; set; } = new List<Colaborador>();
        public IList<Cargo> Cargos { get; set; } = new List<Cargo>();
    }
}
