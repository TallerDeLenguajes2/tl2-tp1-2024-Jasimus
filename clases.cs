using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using Cadete_space;
using Cadeteria_space;
using Pedido_space;

namespace Clases
{

    public static class Visual
    {
        public static void VerCadetes(Cadeteria cad)
        {
            foreach(Cadete c in cad.ListaCadetes)
            {
                Console.WriteLine("Id: "+c.Id);
                Console.WriteLine("Nombre: "+c.Nombre);
                Console.WriteLine("Teléfono: "+c.Telefono);
                if(cad.Pedidos != null)
                {
                    Console.WriteLine("Pedidos:");
                    foreach(Pedido p in cad.Pedidos.Where(ped => ped.Cadete == c))
                    {
                        Console.Write($"\t{p.Nro}. {p.Obs} ");
                        p.VerEstado();
                    }
                }
                Console.WriteLine();
            }
        }

        public static bool VerPedidos(List<Pedido> pedidos)
        {
            if(pedidos != null)
            {
                Console.WriteLine("Pedidos:\n");
                foreach(Pedido p in pedidos)
                {
                    Console.Write(p.Nro + ". " + p.Obs);
                    switch(p.Estado)
                    {
                        case estados.pendiente:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(" Pendiente");
                            break;

                        case estados.entregado:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" Entregado");
                            break;
                        
                        case estados.cancelado:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" Cancelado");
                            break;

                        case estados.asignado:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(" Asignado");
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n");
                }
                return true;
            }
            else
            {
                Console.WriteLine("no hay pedidos aún\n");
                return false;
            }
        }


        public static void VerJornalACobrar(Cadeteria cadeteria)
        {
            int IdC;
            VerCadetes(cadeteria);
            do
            {
                System.Console.Write("ingrese el Id del cadete: ");
            }while(!int.TryParse(Console.ReadLine(), out IdC) || IdC < 0 || IdC >= cadeteria.ListaCadetes.Count());

            System.Console.WriteLine($"Cadete:\n{IdC}. {cadeteria.ListaCadetes[IdC].Nombre}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine($"Jornal a cobrar: {cadeteria.JornalACobrar(IdC)}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public static class Accion
    {
        public static List<Pedido> AgregarPedidos(List<Pedido> pedidos)
        {
            string r;
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

        public static List<Pedido> CambiarEstadoPedido(List<Pedido> pedidos)
        {
            int nroP, i=0, est;
            bool hay = false;
            if(Visual.VerPedidos(pedidos))
            {

                do
                {
                    i=0;
                    Console.Write("\nnro de pedido: ");
                    int.TryParse(Console.ReadLine(), out nroP);
                    foreach(Pedido p in pedidos)
                    {
                        if(p.Nro == nroP)
                        {
                            hay = true;
                            break;
                        }
                        i++;
                    }
                }while(!hay);

                Console.WriteLine("estado del pedido:\n1. Pendiente\n2. Entregado\n3. Cancelado");
                do
                {
                    if(!int.TryParse(Console.ReadLine(), out est) || est<1 || est>3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fallo");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        break;
                    }
                }while(true);

                switch(est)
                {
                    case 1:
                        pedidos[i].Estado = estados.pendiente;
                        break;
                    case 2:
                        pedidos[i].Estado = estados.entregado;
                        break;
                    case 3:
                        pedidos[i].Estado = estados.cancelado;
                        break;
                }
            }

            return pedidos;
        }
            public static Cadeteria ReasignarPedidos(Cadeteria cadeteria)
            {
                int IdC, nroP, IdCR;
                Pedido pedido = null;
                Console.WriteLine("Pedidos/Cadete:");
                foreach(Cadete c in cadeteria.ListaCadetes)
                {
                    Console.WriteLine($"{c.Id}. {c.Nombre}");
                    foreach(Pedido p in PedidosCadete(cadeteria, c.Id))
                    {
                        Console.Write($"{p.Nro}. {p.Obs} ");
                        p.VerEstado();
                    }
                }

                do
                {
                    Console.Write("Cadete: ");
                }while(!int.TryParse(Console.ReadLine(), out IdC) || IdC < 0 || IdC >= cadeteria.ListaCadetes.Count());
                
                do
                {
                    Console.Write("Pedido: ");
                    if(int.TryParse(Console.ReadLine(), out nroP))
                    {
                        pedido = PedidosCadete(cadeteria, IdC).Single(ped => ped.Nro == nroP);
                    }
                }while(pedido == null);

                do
                {
                    Console.Write("reasignar a cadete: ");
                }while(!int.TryParse(Console.ReadLine(), out IdCR) || IdCR < 0 || IdCR >= cadeteria.ListaCadetes.Count() || IdCR == IdC);

                pedido.Cadete = cadeteria.ListaCadetes[IdCR];

                return cadeteria;
            }

            public static void CalcularInforme(Cadeteria cadeteria)
            {
                int cantTotal = 0;
                float precioPedido = 10000;
                double ganancia;

                foreach(Cadete c in cadeteria.ListaCadetes)
                {
                    cantTotal += c.CantidadEntregas(cadeteria.Pedidos);
                }
                ganancia = precioPedido * cantTotal;

                foreach(Cadete c in cadeteria.ListaCadetes)
                {
                    ganancia -= cadeteria.JornalACobrar(c.Id);
                }

                Console.WriteLine($"Ganancia Total: ${ganancia}\n");
                Console.WriteLine("Cantidad de envíos de cada cadete:\n");
                foreach(Cadete c in cadeteria.ListaCadetes)
                {
                    System.Console.Write($"{c.Id}. {c.Nombre}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.Write($" {c.CantidadEntregas(cadeteria.Pedidos)}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                System.Console.WriteLine($"\nCantidad total de entregas: {cantTotal}");
            }
            public static List<Pedido> PedidosCadete(Cadeteria cadeteria, int IdC)
            {
                List<Pedido> ped = cadeteria.Pedidos.Where(p => p.Cadete.Id == IdC).ToList();
                return ped;
            }
    }

    public class AccesoADatos
    {
        protected string url;
        public virtual List<Cadete> GenerarListaCadetes()
        {
            return new List<Cadete>();
        }
    }

    public class AccesoCSV : AccesoADatos
    {
        public AccesoCSV(string nombreArchivo)
        {
            url = "./" + nombreArchivo + ".csv";
        }
        public override List<Cadete> GenerarListaCadetes()
        {
            List<Cadete> cadetes = new List<Cadete>();
            using(StreamReader reader = new StreamReader(url))
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
    }

    public class AccesoJSON : AccesoADatos
    {
        public AccesoJSON(string nombreArchivo)
        {
            url = "./" + nombreArchivo + ".json";
        }

        public override List<Cadete> GenerarListaCadetes()
        {
            string? cadS = null;
            if(File.Exists(url))
            {
                cadS = File.ReadAllText(url);
            }
            List<Cadete> cadetes = JsonSerializer.Deserialize <List<Cadete>> (cadS);

            return cadetes;
        }
    }
    public static class LeerCSV
    {
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

        public static void EscribirEnJson(List<Cadete> cadetes, string nombreArchivo)
        {
            string url = "./" + nombreArchivo + ".json";
            string c = JsonSerializer.Serialize(cadetes);

            File.WriteAllText(url, c);
        }
    }
}