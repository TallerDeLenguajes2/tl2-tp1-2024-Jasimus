using Cadete_space;
using Pedidos_space;

namespace Cadeteria
{
    public class Cadeteria
    {
        // private List<Cadete> listaCadetes;
        public List<Pedidos> listadoPedidos;
        public Cadeteria(List<Cadete> cadetes)
        {
            listaCadetes = cadetes;
        }

        private double JornalACobrar(int idC)
        {
            double jornal = 2000;
            foreach(Pedido p in Pedidos)
            {
                if(p.Cadete.Id == idC)
                {
                    if(p.Estado == estado.entregado)
                    {
                        jornal += 500;            
                    }
                }
            }
            return jornal;
        }

        private void AsignarCadete()
        {
            
        }
    }
}