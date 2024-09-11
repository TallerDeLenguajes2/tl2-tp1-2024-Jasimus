using Pedido_space;
namespace Cadete_space
{
    public class Cadete
    {
        private int id;
        private string? nombre;
        private string? direccion;
        private string? telefono;

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }


        public Cadete(int id, string nombre, string direccion, string tel)
        {
            Id = id;
            Nombre = nombre;
            this.direccion = direccion;
            Telefono = tel;
        }

        public Cadete()
        {}

        // public void PedidoEntregado()
        // {
        //     foreach(Pedido p in ListadoPedidos)
        //     {
        //         if(p.Estado != estados.pendiente)
        //         {
        //             ListadoPedidos.Remove(p);
        //         }
        //     }
        // }

        public int CantidadEntregas(List<Pedido> pedidos)
        {
            int cant = 0;
            if(pedidos != null)
            {
                cant = pedidos.Where(p => p.Estado == estados.entregado && p.Cadete.Id == Id).Count();
            }
            return cant;
        }
    }
}