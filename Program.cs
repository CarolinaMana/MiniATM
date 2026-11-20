namespace MiniATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cuenta = new CuentaBancaria(saldoInicial: 1000.00m);
            var consola = new ConsolaATM();
            var servicioATM = new ServicioATM(cuenta, consola);

            servicioATM.Iniciar();
        }
    }
}