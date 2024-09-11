using Pedido_space;
using Cadete_space;
using Clases;
namespace Cadeteria_space
{
    public class Cadeteria
    {
        string nombre;
        string telefono;
        private List<Cadete> listaCadetes;
        private List<Pedido> pedidos = null;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }


        public Cadeteria(string nombre, string tel)
        {
            Nombre = nombre;
            Telefono = tel;            
        }

        public void AsignarPedidos()
        {
            foreach(Pedido p in pedidos)
            {
                if(p.Estado != estados.asignado) p.AsignarCadete(listaCadetes);
            }
        }

        public Pedido AsignarCadeteAPedido(int idC, int nroP)
        {
            Pedido p = pedidos.Single(ped => ped.Nro == nroP);
            p.Estado = estados.asignado;
            p.Cadete = ListaCadetes[idC];
            
            return p;
        }


        public double JornalACobrar(int IdCadete)
        {
            double jornal = 2000;
            if(pedidos != null)
            {
                int cant = pedidos.Count(p => p.Estado == estados.entregado && p.Cadete.Id == IdCadete);
                jornal += 500*cant;
            }

            return jornal;
        }
    }
}
