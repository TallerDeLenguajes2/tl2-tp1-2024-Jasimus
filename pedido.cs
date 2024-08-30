using Cadete_space;
using Cliente_space;
namespace Pedidos_space
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
        public Cadete Cadete { get => cadete; }

        public void VerDireccionCliente()
        {

        }

        public void VerDatosCliente()
        {

        }

        public void TomarPedido(int nro, string obs, string nombreC, string direcc, string tel, string drd)
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = nombreC;
            cliente.Direccion = direcc;
            cliente.Telefono = tel;
            cliente.DatosReferenciaDireccion = drd;
            this.cliente = cliente;
            Nro = nro;
            Obs = obs;

            Cadete cadete = new Cadete();
            
        }
    }

    enum estados
    {
        pendiente 0,
        entregado 1,
        cancelado 2
    }
}
