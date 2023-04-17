namespace Entities
{
    public class Movimentacao{

        private double valor_minuto = 0.25;
        public Guid Id { get; }
        public Guid VeiculoId { get; }
        public Guid ClienteId { get; }
        public DateTime Entrada { get; }
        public DateTime Saida { get; }
        public int Duracao { get; set; }
        public double Valor { get; set; }

        public Movimentacao(Veiculo veic, int duracao) 
        {
            Id = Guid.NewGuid();
            VeiculoId = veic.Id;
            ClienteId = veic.ClienteId;
            Duracao = duracao;
            Entrada = DateTime.Now;
            Saida = Entrada.AddMinutes(duracao);

            Valor = duracao * valor_minuto;
        }

        public Movimentacao(Veiculo veic, DateTime saida) 
        {
            Id = Guid.NewGuid();
            VeiculoId = veic.Id;
            ClienteId = veic.ClienteId;
            Entrada = DateTime.Now;
            Saida = saida;

            TimeSpan diff = Saida - Entrada;

            Duracao = (int)diff.TotalMinutes;

            Valor = Duracao * valor_minuto;
        }

        public Movimentacao(){}
    }
}