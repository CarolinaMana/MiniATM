
using System;

namespace MiniATM
{
    
    public class ServicioATM
    {
        private readonly CuentaBancaria _cuenta;
        private readonly ConsolaATM _consola;

        public ServicioATM(CuentaBancaria cuenta, ConsolaATM consola)
        {
            _cuenta = cuenta ?? throw new ArgumentNullException(nameof(cuenta));
            _consola = consola ?? throw new ArgumentNullException(nameof(consola));
        }

        public void Iniciar()
        {
            bool ejecutando = true;

            while (ejecutando)
            {
                _consola.MostrarMenu();
                int opcion = _consola.LeerOpcionMenu();

                switch (opcion)
                {
                    case 1:
                        ConsultarSaldo();
                        break;
                    case 2:
                        ProcesarDeposito();
                        break;
                    case 3:
                        ProcesarRetiro();
                        break;
                    case 4:
                        ejecutando = false;
                        _consola.MostrarMensaje("\nGracias por utilizar el Mini ATM. ¡Hasta pronto!");
                        break;
                }
            }
        }

        private void ConsultarSaldo()
        {
            _consola.MostrarSaldo(_cuenta.Saldo);
        }

        private void ProcesarDeposito()
        {
            try
            {
                decimal monto = _consola.LeerMonto("Ingrese el monto a depositar: ");
                _cuenta.Depositar(monto);
                _consola.MostrarExito($"Depósito de {monto:C} realizado correctamente.");
                _consola.MostrarSaldo(_cuenta.Saldo);
            }
            catch (ArgumentException ex)
            {
                _consola.MostrarError(ex.Message);
            }
        }

        private void ProcesarRetiro()
        {
            try
            {
                decimal monto = _consola.LeerMonto("Ingrese el monto a retirar: ");
                _cuenta.Retirar(monto);
                _consola.MostrarExito($"Retiro de {monto:C} realizado correctamente.");
                _consola.MostrarSaldo(_cuenta.Saldo);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                _consola.MostrarError(ex.Message);
            }
        }
    }
}
