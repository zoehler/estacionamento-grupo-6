/*
sistema de gestão de entradas e saidas de um veiculo (estacionamento)
cliente
    id (auto)
    nome
    cpf

veiculo
    cliente_id
    marca
    modelo
    placa

movimentacao
    data/hora entrada
    data/hora saida

tabela_de_preco
    valor_por_minuto

No final da operação, ou seja quando o cliente estiver saindo o 
estacionamento mostrar o valor total que ele pagará no estacionamento


DateTime data1 = DateTime.Now;
DateTime data2 = DateTime.Now.AddDays(-2); // data anterior a data1, para efeito de exemplo

TimeSpan diff = data1 - data2;

int minutos = (int)diff.TotalMinutes;

OPÇÕES DO MENU
- CADASTRO DE CLIENTES
- CADASTRO DE VEICULO
- CRIAÇÃO DE MOVIMENTAÇÃO (com hora fixa)

*/
using System.Globalization;
using Entities;

var clientes = new List<Cliente>();
var veiculos = new List<Veiculo>();
var movimentacao = new List<dynamic>();


while (true)
{
    Console.Clear();
    Console.WriteLine("Digite uma das opções abaixo:");
    Console.WriteLine("1 - Cadastrar Cliente");
    Console.WriteLine("2 - Listar Cliente");
    Console.WriteLine("0 - Sair");

    var opcao = Console.ReadLine();
    var sair = false;

    switch (opcao)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Digite o nome do cliente");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o CPF do cliente");
            string cpf = Console.ReadLine();

            Cliente cliente = new Cliente(nome, cpf);

            Console.WriteLine("Cliente cadastrado com sucesso.");

            Console.WriteLine("-------------------");
            Console.WriteLine("Cadastro do veículo");
            Console.WriteLine("Digite a marca do veículo");
            string marca = Console.ReadLine();
            Console.WriteLine("Digite o modelo do veículo");
            string modelo = Console.ReadLine();
            Console.WriteLine("Digite a placa do veículo");
            string placa = Console.ReadLine();

            Veiculo veiculo = new Veiculo(cliente, marca, modelo, placa);

            cliente.veiculos.Add(veiculo);

            Console.WriteLine("Veículo cadastrado com sucesso.");


            Console.WriteLine("-------------------");
            Console.WriteLine("Cadastro de movimentação");


            Console.WriteLine("Escolha o tipo de inserção de dados:");
            Console.WriteLine("1 - Inserção de duração total da estadia");
            Console.WriteLine("2 - Inserção do horário exato de saída (dd/mm/aaaa hh:mm)");
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || (escolha != 1 && escolha != 2))
            {
                Console.WriteLine("Valor inválido, insira novamente!");
            }

            // do
            // {
            //     escolha = Console.ReadLine();
            //     if(escolha != "1" && escolha != "2") {
            //         Console.WriteLine("Valor inválido, insira novamente!");
            //     } else {
            //         break;
            //     }
                
            // } while (true);

            Movimentacao mov = new Movimentacao();
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Digite quanto tempo o veículo ficará estacionado, em minutos:");
                    int duracao;
                    while (!int.TryParse(Console.ReadLine(), out duracao))
                    {
                        Console.WriteLine("Valor inválido, insira novamente!");
                    }

                    mov = new Movimentacao(veiculo, duracao);

                    Console.WriteLine($"O valor da estadia é de {mov.Valor}!");

                    break;
                case 2:
                
                    Console.WriteLine("Digite insira a data e horário da saída, no seguinte formato (dd/MM/yyyy HH:mm):");
                    DateTime dataHora;
                    while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm",
                    CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out dataHora) || dataHora < DateTime.Now)
                    {
                        Console.WriteLine("Valor inválido, insira novamente!");
                    }
                    mov = new Movimentacao(veiculo, dataHora);

                    Console.WriteLine($"O valor da estadia é de {mov.Valor}!");
                    break;
            }


            cliente.movimentacoes.Add(mov);
            clientes.Add(cliente);
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadKey();
            break;
        case "2":
            Console.WriteLine("===== Lista de clientes =====");
            foreach (var cli in clientes)
            {
                Console.WriteLine($"ID: {cli.Id}");
                Console.WriteLine($"Nome: {cli.Nome}");
                Console.WriteLine($"CPF: {cli.CPF}");
                Console.WriteLine("------------------------------");
                Console.WriteLine("########## Veículos:");

                foreach (var veic in cli.veiculos)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"ID: {veic.Id}");
                    Console.WriteLine($"Marca: {veic.Marca}");
                    Console.WriteLine($"Modelo: {veic.Modelo}");
                    Console.WriteLine($"Placa: {veic.Placa}");
                    Console.WriteLine("-----------------");
                }

                Console.WriteLine("########## Movimentações:");
                foreach (var movi in cli.movimentacoes)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"ID: {movi.Id}");
                    Console.WriteLine($"Entrada: {movi.Entrada}");
                    Console.WriteLine($"Saída: {movi.Saida}");
                    Console.WriteLine($"Duração: {movi.Duracao}");
                    Console.WriteLine($"Valor: R${movi.Valor}");
                    Console.WriteLine("-----------------");
                }
            }

            Console.WriteLine("Pressione Enter para continuar ...");
            Console.ReadKey();
            break;
        default:
            sair = true;
            break;
    }

    if (sair) break;
}