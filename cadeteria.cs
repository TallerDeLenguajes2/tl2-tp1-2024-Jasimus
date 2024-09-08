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
        private List<Pedido> pedidos = new List<Pedido>();

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }


        public Cadeteria(string nombre, string tel)
        {
            Nombre = nombre;
            Telefono = tel;            
        }

        public void ActualizarCadetes(List<Cadete> lcadetes)
        {
            ListaCadetes = lcadetes;
        }

        public void AsignarPedidos()
        {
            foreach(Pedido p in pedidos)
            {
                p.AsignarCadete(listaCadetes);
            }
        }

        public void AsignarPedidosManual()
        {
            int idC;
            int numP;
            bool s = true;
            string d;
            Pedido p;
            while(s)
            {
                Visual.VerPedidos(pedidos);
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
                p.Cadete = ListaCadetes[idC];

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


        public double JornalACobrar(int IdCadete)
        {
            double jornal = 2000;
            int cant = pedidos.Count(p => p.Estado == estados.entregado && p.Cadete.Id == IdCadete);
            jornal += 500*cant;

            return jornal;
        }
    }
}
