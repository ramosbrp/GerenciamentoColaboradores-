namespace GerenciamentoColaboradores.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; } = new Cargo();
    }
}
