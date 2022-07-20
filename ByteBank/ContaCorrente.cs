using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank
{
    public class ContaCorrente
    {
        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
                throw new ArgumentException("A agência ser maior que 0.", nameof(agencia));
            }
            if (numero <= 0)
            {
                throw new ArgumentException("O número devem ser maior que 0.", nameof(numero));
            }
            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;
            TaxaOperacao = 30.00 / (TotalDeContasCriadas * 1.0);
        }
        public static double TaxaOperacao { get; private set; }

        public static int TotalDeContasCriadas { get; private set; }
       
        public int ContadorSaquesNaoPermitidos { get; private set; }

        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public Cliente Titular { get; set; }

        public int Agencia { get; }

        public int Numero { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get { return _saldo; }
            private set
            {
                if (_saldo - value < 0 || _saldo + value < 0)
                {
                    return;
                }
                else
                {
                    _saldo = value;
                }
            }
        }



        public void Sacar(double valor)
        {
            if (valor <= 0)
            {
                //o atb lançado como parametro de nameof, representa o atb a ser contido no ParamName
                throw new ArgumentException($"Exceção vinda do Sacar()\n" +
                    $"Valor inválido para a transação", nameof(valor));
            }
            if (Saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }
            else
            {
                Saldo -= valor;

            }
        }


        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Exceção vinda do Depositar()\n" +
                    "Valor de transação inválido", nameof(valor));
            }
            else
            {
                this._saldo += valor;
            }

        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (contaDestino == null)
            {
                //o atb lançado como parametro de nameof, representa o atb a ser contido no ParamName
                throw new NullReferenceException($"Exceção vinda do transferir\n Conta não localizada");
            }


            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw;
            }
            contaDestino.Depositar(valor);
            ;

        }

    }
}
