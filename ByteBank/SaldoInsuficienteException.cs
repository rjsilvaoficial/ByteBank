using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank
{
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException() { }

        public SaldoInsuficienteException(string mensagem) : base(mensagem) { }

        //Ao chamar um outro construtor pelo this incluindo a msg, teremos uma instancia
        //Que alimenta o valor das props Saldo e ValorSaque da exceção
        //Que invoca um construtor secundário e o imbui da msg de erro definida
        //Este construtor secundário por sua vez, envia essa informação ao construtor base
        //Evitando cópias de código em caso de alterações no construtor com msg de SaldoInsuficienteException
        
        public SaldoInsuficienteException(double saldo, double valorSaque) 
            : this($"Exceção que chama construtor de si mesma\nTentativa de saque com valor maior que saldo disponível!")
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }

        public SaldoInsuficienteException(string mensagem, Exception innerException) 
            : base(mensagem, innerException)
        {

        }

        public double Saldo { get; }
        public double ValorSaque { get; }


    }
}
