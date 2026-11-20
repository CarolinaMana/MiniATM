using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniATM
{
    public class CuentaBancaria
    {
        public decimal Saldo { get; private set; }

        public CuentaBancaria(decimal saldoInicial = 0m)
        {
            if (saldoInicial < 0)
            {
                throw new ArgumentException("El saldo inicial no puede ser negativo.", nameof(saldoInicial));
            }

            Saldo = saldoInicial;
        }

        public void Depositar(decimal monto)
        {
            ValidarMontoPositivo(monto);
            Saldo += monto;
        }

        public void Retirar(decimal monto)
        {
            ValidarMontoPositivo(monto);

            if (monto > Saldo)
            {
                throw new InvalidOperationException("Fondos insuficientes para realizar el retiro.");
            }

            Saldo -= monto;
        }

        private static void ValidarMontoPositivo(decimal monto)
        {
            if (monto <= 0)
            {
                throw new ArgumentException("El monto de la operación debe ser mayor a cero.");
            }
        }
    }
} 
    
    