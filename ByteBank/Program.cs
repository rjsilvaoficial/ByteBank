using System;

namespace ByteBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContaCorrente c1 = new ContaCorrente(agencia: 01, numero: 01);
                c1.Titular = new Cliente { Nome = "01" };
                Console.WriteLine("Dados da conta" + c1.Numero);
                Console.WriteLine($"Agência {c1.Agencia}  Número da conta {c1.Numero}");
                Console.WriteLine($"Nome cliente {c1.Titular.Nome}  saldo {c1.Saldo}");

                ContaCorrente c2 = new ContaCorrente(agencia: 02, numero: 02);
                c2.Titular = new Cliente { Nome = "02" };
                c2.Depositar(159);
                Console.WriteLine($"Agência {c2.Agencia}  Número da conta {c2.Numero}");
                Console.WriteLine($"Nome cliente {c2.Titular.Nome}  saldo {c2.Saldo}");

                c1.Transferir(200, c2);
            }
            catch (ArgumentException)
            {

            }
            catch (SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception)
            {

            }

        }
    }
}





