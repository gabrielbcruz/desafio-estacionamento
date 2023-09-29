using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AdicionarVeiculo(string placa)
        {
            veiculos.Add(placa);
            Console.WriteLine($"Veículo com placa {placa} estacionado.");
        }

        public void RemoverVeiculo(string placa, int horasEstacionado)
        {
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                decimal valorTotal = precoInicial + (precoPorHora * horasEstacionado);
                veiculos.Remove(placa);
                Console.WriteLine($"Veículo com placa {placa} removido. Valor a ser cobrado: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            decimal precoInicial = 0;
            decimal precoPorHora = 0;

            Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!\n" +
                              "Digite o preço inicial:");
            precoInicial = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Agora digite o preço por hora:");
            precoPorHora = Convert.ToDecimal(Console.ReadLine());

            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

            string opcao = string.Empty;
            bool exibirMenu = true;

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
                        Console.Write("Digite a placa do veículo: ");
                        string placaAdicionar = Console.ReadLine();
                        estacionamento.AdicionarVeiculo(placaAdicionar);
                        break;

                    case "2":
                        Console.Write("Digite a placa do veículo a ser removido: ");
                        string placaRemover = Console.ReadLine();
                        Console.Write("Digite a quantidade de horas estacionado: ");
                        int horasEstacionado = int.Parse(Console.ReadLine());
                        estacionamento.RemoverVeiculo(placaRemover, horasEstacionado);
                        break;

                    case "3":
                        estacionamento.ListarVeiculos();
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
        }
    }
}

            Console.ReadLine();
        }
    }
}
