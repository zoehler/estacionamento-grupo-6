namespace Entities
{
    public class Cliente
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string CPF { get; }

        public List<Veiculo> veiculos { get; set; }
        public List<Movimentacao> movimentacoes { get; set; }

        public Cliente(Guid id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
        }

        public Cliente(string nome, string cpf)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            veiculos = new List<Veiculo>();
            movimentacoes = new List<Movimentacao>();
        }
    }
}