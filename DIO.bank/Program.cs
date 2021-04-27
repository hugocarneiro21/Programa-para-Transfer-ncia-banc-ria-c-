using System;
using System.Collections.Generic;

namespace DIO.bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void Sacar()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);



        }

        private static void Transferir()
        {
            Console.Write("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double ValorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(ValorTransferencia, listContas[indiceContaDestino]);

        }

        private static void Depositar()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double ValorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(ValorDeposito);



        }

        private static void InserirConta()
        {
            System.Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta Física ou 2 para conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string EntradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double EntradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("digite o crédito: ");
            double EntradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                         Saldo: EntradaSaldo,
                                         Credito: EntradaCredito,
                                         nome: EntradaNome);
            listContas.Add(novaConta);

        }

        private static void ListarContas()
        {

            System.Console.WriteLine("Listar Contas");
            if (listContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                System.Console.WriteLine(conta);
            }


        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Bank a seu dispor!!!");
            System.Console.WriteLine("Informe a opçao desejada:");
            System.Console.WriteLine("1 - Listar contas");
            System.Console.WriteLine("2 - Inserir nova Conta");
            System.Console.WriteLine("3 - Transferir");
            System.Console.WriteLine("4 - Sacar");
            System.Console.WriteLine("5 - Depositar");
            System.Console.WriteLine("C - Limpar a tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}