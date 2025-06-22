namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            // Validação simples para garantir que a placa é válida (não pode ser nula ou vazia)
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Por favor, digite uma placa válida.");
                return;
            }

            // Adiciona a placa do veículo à lista
            veiculos.Add(placa.ToUpper());
            Console.WriteLine($"O veículo {placa.ToUpper()} foi estacionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Validação para garantir que o valor inserido é um número válido e positivo
                try
                {
                    int quantidadeHorasEstacionado = Convert.ToInt32(Console.ReadLine());

                    // Validação para garantir que o valor inserido é positivo
                    if (quantidadeHorasEstacionado < 0)
                    {
                        Console.WriteLine("Quantidade de horas inválida. Por favor, insira um número válido.");
                        return;
                    }

                    // Realizar o cálculo do valor total
                    decimal valorTotal = precoInicial + precoPorHora * quantidadeHorasEstacionado;

                    // Remove o veículo da lista
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {Math.Round(valorTotal, 2)}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um número válido para a quantidade de horas.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
