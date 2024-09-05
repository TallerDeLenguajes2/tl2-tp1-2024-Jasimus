using System.Runtime.InteropServices;
using Cadete_space;
using Cadeteria_space;
using Pedido_space;

namespace Clases
{
    public static class LeerCSV
    {
        public static List<Cadete> GenerarListaCadetes()
        {
            string path = "./CSV_cadete.csv";
            List<Cadete> cadetes = new List<Cadete>();
            using(StreamReader reader = new StreamReader(path))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] campos = line.Split(',');
                    Cadete cadete = new Cadete(int.Parse(campos[0]), campos[1], campos[2], campos[3]);
                    cadetes.Add(cadete);
                }
            }

            return cadetes;
        }

        public static Cadeteria GenerarCadeteria()
        {
            string path = "./CSV_cadeteria.csv";
            List<string> lines = new List<string>(File.ReadAllLines(path));
            Random rand = new Random();
            int i = rand.Next(3);

            string[] campos = lines[i].Split(',');

            Cadeteria cad = new Cadeteria(campos[0], campos[1]);

            return cad;
        }
    }

    public static class Visual
    {
        public static void VerCadetes(Cadeteria cad)
        {
            foreach(Cadete c in cad.ListaCadetes)
            {
                Console.WriteLine("Id: "+c.Id);
                Console.WriteLine("Nombre: "+c.Nombre);
                Console.WriteLine("Teléfono: "+c.Telefono);
                Console.WriteLine("Pedidos:");
                foreach(Pedido p in c.ListadoPedidos)
                {
                    Console.WriteLine("\t"+p.Nro);
                }
            }
        }
    }

    public static class Accion
    {
        public static List<Pedido> AgregarPedidos()
        {
            string r;
            List<Pedido> pedidos = new List<Pedido>();
            do
            {
                Console.WriteLine("Desea agregar un pedido nuevo?\ns. Si\nn. No");
                r = Console.ReadLine();
                if(string.Equals(r,"s"))
                {
                    string nroS;
                    int nro;
                    Console.WriteLine("\nDatos del pedido");
                    do
                    {
                        Console.Write("nro: ");
                        nroS = Console.ReadLine();
                    }while(!int.TryParse(nroS, out nro));
                    Console.Write("Observación: ");
                    string Obs = Console.ReadLine();
                    Console.WriteLine("\nDatos del cliente");
                    Console.Write("Nombre: ");
                    string nombreC = Console.ReadLine();
                    Console.Write("Dirección: ");
                    string dirC = Console.ReadLine();
                    Console.Write("Teléfono: ");
                    string telC = Console.ReadLine();
                    Console.Write("Datos Referencia Dirección: ");
                    string drd = Console.ReadLine();

                    Pedido p = new Pedido(nro, Obs, nombreC, dirC, telC, drd);
                    pedidos.Add(p);
                }
            }while(string.Equals(r,"s"));

            return pedidos;

        }
    }
}