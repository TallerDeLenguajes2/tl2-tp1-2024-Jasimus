using Pedido_space;
using Cadete_space;
using System.Drawing;
namespace Cadeteria_space
{
    public class Cadeteria
    {
        string nombre;
        string telefono;
        private List<Cadete> listaCadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }

        public Cadeteria(string nombre, string tel)
        {
            Nombre = nombre;
            Telefono = tel;            
        }

        public void ActualizarCadetes(List<Cadete> lcadetes)
        {
            ListaCadetes = lcadetes;
        }

        public void AsignarPedidos(List<Pedido> pedidos)
        {
            int cant = ListaCadetes.Count();
            Random rand = new Random();

            foreach(Pedido p in pedidos)
            {
                int i = rand.Next(cant);
                ListaCadetes[i].TomarPedido(p);
            }
        }

        public void AsignarPedidosManual(List<Pedido> pedidos)
        {
            Console.WriteLine("Pedidos:\n");
            foreach(Pedido p in pedidos)
            {
                Console.Write(p.Nro + ". " + p.Obs);
                if(p.Estado == estados.pendiente)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(" Pendiente");
                }
                else if(p.Estado == estados.entregado)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Entregado");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Cancelado");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }

            Console.WriteLine("\nCadetes:\n");
            foreach(Cadete c in listaCadetes)
            {
                Console.WriteLine(c.Id + ". " + c.Nombre);
            }
        }
    }
}