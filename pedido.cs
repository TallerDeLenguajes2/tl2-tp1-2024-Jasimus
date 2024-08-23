namespace Pedido
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

        public void VerDireccionCliente()
        {

        }

        public void VerDatosCliente()
        {

        }
    }

    enum estados
    {
        pendiente 0,
        entregado 1,
        cancelado 2
    }
}
