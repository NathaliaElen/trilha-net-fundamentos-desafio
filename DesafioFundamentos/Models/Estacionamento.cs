using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions; // <-- ESSENCIAL PARA O REGEX FUNCIONAR

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
            string placa = Console.ReadLine().ToUpper();

            // Validação simples para garantir que a placa é válida (não pode ser nula ou vazia)
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Por favor, digite uma placa válida.");
                return;
            }

            // Validação do formato da placa (Padrão Mercosul)
            if (!PlacaValida(placa))
            {
                Console.WriteLine("Formato de placa inválido. Exemplo de formato válido: ABC1D23");
                return;
            }

            // Adiciona a placa do veículo à lista
            veiculos.Add(placa);
            Console.WriteLine($"O veículo {placa} foi estacionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            // Validação do formato da placa (Padrão Mercosul)
            if (!PlacaValida(placa))
            {
                Console.WriteLine("Formato de placa inválido. Exemplo de formato válido: ABC1D23");
                return;
            }

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

        private const string PadraoMercosul = @"^[A-Z]{3}[0-9][A-Z][0-9]{2}$";

        private bool PlacaValida(string placa)
        {
            return Regex.IsMatch(placa, PadraoMercosul);
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (string listaVeiculos in veiculos)
                {
                    Console.WriteLine(listaVeiculos);
                }

                Console.WriteLine($"Total de veículos na lista: {veiculos.Count}");
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
