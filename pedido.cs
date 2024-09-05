using Cliente_space;
namespace Pedido_space
{
    public class Pedido
    {
        int nro;
        string? obs;
        Cliente cliente;
        estados estado;

        public int Nro { get => nro; set => nro = value; }
        public string? Obs { get => obs; set => obs = value; }
        public estados Estado { get => estado; set => estado = value; }


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
    }

    public enum estados
    {
        pendiente = 0,
        entregado = 1,
        cancelado = 2
    }
}
