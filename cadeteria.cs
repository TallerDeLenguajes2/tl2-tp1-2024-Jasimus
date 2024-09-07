using Pedido_space;
using Cadete_space;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Clases;
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
            int idC;
            int numP;
            bool s = true;
            string d;
            Pedido p;
            Visual.VerPedidos(pedidos);
            while(s)
            {
                Console.WriteLine("\nCadetes:\n");
                foreach(Cadete c in listaCadetes)
                {
                    Console.WriteLine(c.Id + ". " + c.Nombre);
                }
                do
                {
                    Console.Write("\nID cadete: ");
                }while(!int.TryParse(Console.ReadLine(), out idC) || idC < 0 || idC > listaCadetes.Count-1);

                do
                {
                    Console.Write("\nNúmero pedido: ");
                    if(int.TryParse(Console.ReadLine(), out numP) && pedidos.Any(p => p.Nro == numP))
                    {
                        p = pedidos.Find(p => p.Nro == numP);
                        if(p.Estado == estados.asignado)
                        {
                            System.Console.WriteLine("El pedido ya está asignado a otro cadete");
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("El pedido no existe");
                    }
                }while(true);
                p.Estado = estados.asignado;
                listaCadetes[idC].ListadoPedidos.Add(p);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"se asignó el pedido \"{pedidos[numP-1].Obs}\" al cadete {listaCadetes[idC].Nombre}");
                Console.ForegroundColor = ConsoleColor.White;

                do
                {
                    Console.WriteLine("\nDesea asignar otro pedido?\ns. Si\nn. No");
                    d = Console.ReadLine();
                }while(!string.Equals(d, "s") && !string.Equals(d, "n"));

                if(string.Equals(d, "n"))
                {
                    s = false;
                }
            }
        }
    }
}