using Cliente_space;
using Cadete_space;
namespace Pedido_space
{
    public class Pedido
    {
        int nro;
        string? obs;
        Cliente cliente;
        Cadete cadete;
        estados estado;

        public int Nro { get => nro; set => nro = value; }
        public string? Obs { get => obs; set => obs = value; }
        public estados Estado { get => estado; set => estado = value; }
        public Cadete Cadete { get => cadete; set => cadete = value; }

        public Pedido(int nro, string obs, string nombreCliente, string dirCliente, string telCliente, string datosReferenciaDireccion)
        {
            this.nro = nro;
            this.obs = obs;
            cliente = new Cliente(nombreCliente, dirCliente, telCliente, datosReferenciaDireccion);
        }

        public void VerDireccionCliente()
        {
            Console.WriteLine(cliente.Direccion);
        }

        public void VerDatosCliente()
        {
            Console.WriteLine($"Nombre: {cliente.Nombre}\nTeléfono: {cliente.Telefono}\nDirección: {cliente.Direccion}\nDatos de referencia dirección: {cliente.DatosReferenciaDireccion}");
        }

        public void AsignarCadete(List<Cadete> cadetes)
        {
            Random rand = new Random();
            int i = rand.Next(0, cadetes.Count());
            Cadete = cadetes[i];
            estado = estados.asignado;
        }

        public void VerEstado()
        {
            switch(Estado)
                    {
                        case estados.pendiente:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(" Pendiente");
                            break;

                        case estados.entregado:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" Entregado");
                            break;
                        
                        case estados.cancelado:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" Cancelado");
                            break;

                        case estados.asignado:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(" Asignado");
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n");
        }
    }

    public enum estados
    {
        pendiente = 0,
        entregado = 1,
        cancelado = 2,
        asignado = 3
    }
}
