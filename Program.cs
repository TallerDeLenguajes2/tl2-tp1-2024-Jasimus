using Clases;
using Cadete_space;
using Cadeteria_space;
using Pedido_space;

string nombreArchivoCadetes = "cadetes";
AccesoCSV accesoCSV = new AccesoCSV(nombreArchivoCadetes);
AccesoJSON accesoJSON = new AccesoJSON(nombreArchivoCadetes);
List<Cadete> cadetes = null;
Cadeteria cadeteria = LeerCSV.GenerarCadeteria();
string accionS;
int accion, formAsig, archivo;
bool seguir = true;
bool hayAsignados = false;


Console.Clear();
do
{
    Console.WriteLine("desde qué archivo desea cargar los cadetes?\n1. CSV\n2. JSON");
}while(!int.TryParse(Console.ReadLine(), out archivo) || archivo > 2 || archivo < 1);

if(archivo == 1)
{
    cadetes = accesoCSV.GenerarListaCadetes();
}
else
{
    cadetes = accesoJSON.GenerarListaCadetes();
}

cadeteria.ActualizarCadetes(cadetes);
Console.Clear();
while(seguir)
{
    do
    {
        Console.WriteLine("qué acción desea hacer:\n\t1. dar de alta pedidos\n\t2. asignar pedidos a cadetes\n\t3. cambiar estado de pedido\n\t4. reasignar pedidos\n\t5. ver listado de Cadetes\n\t6. ver listado de pedidos\n\t7. jornal a cobrar de un cadete\n\t*. salir");
        accionS = Console.ReadLine();
    }while(!int.TryParse(accionS, out accion) || accion <= 0);

    switch(accion)
    {
        case 1:
            if(cadeteria.Pedidos == null)
            {
                List<Pedido> p = new List<Pedido>();
                cadeteria.Pedidos = Accion.AgregarPedidos(p);
            }
            else
            {
                cadeteria.Pedidos = Accion.AgregarPedidos(cadeteria.Pedidos);
            }
            break;

        case 2:
            Console.Clear();
            if(cadeteria.Pedidos != null)
            {
                do
                {
                    Console.WriteLine("1. de forma automática\n2. de forma manual");
                }while(!int.TryParse(Console.ReadLine(), out formAsig) || formAsig < 1 || formAsig > 2);
                if(formAsig == 1)
                {
                    cadeteria.AsignarPedidos();
                }
                else
                {
                    
                    int idC;
                    int numP;
                    bool s = true;
                    string d;
                    Pedido p;
                    while(s)
                    {
                        Visual.VerPedidos(cadeteria.Pedidos);
                        Console.WriteLine("\nCadetes:\n");
                        foreach(Cadete c in cadeteria.ListaCadetes)
                        {
                            Console.WriteLine(c.Id + ". " + c.Nombre);
                        }
                        do
                        {
                            Console.Write("\nID cadete: ");
                        }while(!int.TryParse(Console.ReadLine(), out idC) || idC < 0 || idC > cadeteria.ListaCadetes.Count-1);

                        do
                        {
                            Console.Write("\nNúmero pedido: ");
                        }while(!int.TryParse(Console.ReadLine(), out numP) || !cadeteria.Pedidos.Any(p => p.Nro == numP));
                        
                        cadeteria.AsignarCadeteAPedido(idC, numP);

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
                hayAsignados = true;
            }
            else
            {
                Console.WriteLine("no hay pedidos");
            }
            break;

        case 3:
            cadeteria.Pedidos = Accion.CambiarEstadoPedido(cadeteria.Pedidos);
            break;

        case 4:
            if(hayAsignados)
            {
                cadeteria = Accion.ReasignarPedidos(cadeteria);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ningún cadete tiene pedidos");
                Console.ForegroundColor = ConsoleColor.White;
            }
            break;

        case 5:
            Visual.VerCadetes(cadeteria);
            break;
        
        case 6:
            Visual.VerPedidos(cadeteria.Pedidos);
            break;
        case 7:
            Visual.VerJornalACobrar(cadeteria);
            break;
        default:
            seguir = false;
            break;

    }
}
Accion.CalcularInforme(cadeteria);

