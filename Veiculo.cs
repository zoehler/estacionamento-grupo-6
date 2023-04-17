namespace Entities
{

    public class Veiculo
    {
        public Guid Id { get; }
        public Guid ClienteId { get; }
        public string Marca { get; }
        public string Modelo { get; }
        public string Placa { get; }

        public Veiculo(Guid id, Cliente cliente, string marca, string modelo, string placa)
        {
            Id = id;
            ClienteId = cliente.Id;
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
        }

        public Veiculo(Cliente cliente, string marca, string modelo, string placa)
        {
            Id = Guid.NewGuid();
            ClienteId = cliente.Id;
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
        }
    }
}
