using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniATM
{
    public class ConsolaATM
    {
        public void MostrarMenu()
        {
            Console.WriteLine("\n=== CAJERO AUTOMÁTICO (MINI ATM) ===");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
        }

        public int LeerOpcionMenu()
        {
            while (true)
            {
                string? entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int opcion) && opcion >= 1 && opcion <= 4)
                {
                    return opcion;
                }

                MostrarError("Opción inválida. Ingrese un número del 1 al 4.");
                Console.Write("Seleccione una opción: ");
            }
        }

        public decimal LeerMonto(string mensajeSolicitud)
        {
            while (true)
            {
                Console.Write(mensajeSolicitud);
                string? entrada = Console.ReadLine();

                if (decimal.TryParse(entrada, out decimal monto))
                {
                    return monto;
                }

                MostrarError("Entrada inválida. Debe ingresar un valor numérico.");
            }
        }

        public void MostrarSaldo(decimal saldo)
        {
            Console.WriteLine($"\n[INFO] Su saldo actual es: {saldo:C}");
        }

        public void MostrarExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n[ÉXITO] {mensaje}");
            Console.ResetColor();
        }

        public void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ERROR] {mensaje}");
            Console.ResetColor();
        }

        public void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
