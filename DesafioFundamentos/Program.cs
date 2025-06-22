using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem-vindo(a) ao sistema de estacionamento!");

// Ler e validar preço inicial
Console.WriteLine("Digite o preço inicial:");
string inputPrecoInicial = Console.ReadLine();

if (!decimal.TryParse(inputPrecoInicial, out precoInicial) || precoInicial < 0)
{
    Console.WriteLine("Entrada inválida. Por favor, insira um valor numérico válido e não negativo para o preço inicial.");
    return;
}

// Ler e validar preço por hora
Console.WriteLine("Agora digite o preço por hora:");
string inputPrecoPorHora = Console.ReadLine();

if (!decimal.TryParse(inputPrecoPorHora, out precoPorHora) || precoPorHora < 0)
{
    Console.WriteLine("Entrada inválida. Por favor, insira um valor numérico válido e não negativo para o preço por hora.");
    return;
}

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
