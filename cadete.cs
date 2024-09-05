using Pedido_space;
namespace Cadete_space
{
    public class Cadete
    {
        private int id;
        private string? nombre;
        private string? direccion;
        private string? telefono;
        private List<Pedido> listadoPedidos = new List<Pedido>();

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; }


        public Cadete(int id, string nombre, string direccion, string tel)
        {
            Id = id;
            Nombre = nombre;
            this.direccion = direccion;
            Telefono = tel;
        }

        public double JornalACobrar()
        {
            double jornal = 2000;
            foreach(Pedido p in ListadoPedidos)
            {
                if(p.Estado == estados.entregado)
                {
                    jornal += 500;
                }
            }

            return jornal;
        }

        public void TomarPedido(Pedido pedido)
        {
            ListadoPedidos.Add(pedido);
        }

        public void PedidoEntregado()
        {
            foreach(Pedido p in ListadoPedidos)
            {
                if(p.Estado != estados.pendiente)
                {
                    ListadoPedidos.Remove(p);
                }
            }
        }

    }
}