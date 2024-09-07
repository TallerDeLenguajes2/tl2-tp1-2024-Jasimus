using Clases;
using Cadete_space;
using Cadeteria_space;
using Pedido_space;

List<Cadete> cadetes = LeerCSV.GenerarListaCadetes();
Cadeteria cadeteria = LeerCSV.GenerarCadeteria();
string accionS;
int accion;
int formAsig;
List<Pedido>pedidos = new List<Pedido>();
bool seguir = true;
bool hayAsignados = false;

cadeteria.ActualizarCadetes(cadetes);
Console.Clear();
Console.ForegroundColor = ConsoleColor.White;
while(seguir)
{
    do
    {
        Console.WriteLine("qué acción desea hacer:\n\t1. dar de alta pedidos\n\t2. asignar pedidos a cadetes\n\t3. cambiar estado de pedido\n\t4. reasignar pedidos\n\t5. ver listado de Cadetes\n\t6. ver listado de pedidos\n\t*. salir");
        accionS = Console.ReadLine();
    }while(!int.TryParse(accionS, out accion) || accion <= 0);

    switch(accion)
    {
        case 1:
            pedidos = Accion.AgregarPedidos(pedidos);
            break;

        case 2:
            Console.Clear();
            if(pedidos != null) 
            {
                do
                {
                    Console.WriteLine("1. de forma automática\n2. de forma manual");
                }while(!int.TryParse(Console.ReadLine(), out formAsig) || formAsig < 1 || formAsig > 2);
                if(formAsig == 1)
                {
                    cadeteria.AsignarPedidos(pedidos);
                }
                else
                {
                    cadeteria.AsignarPedidosManual(pedidos);
                }
                hayAsignados = true;
            }
            else
            {
                Console.WriteLine("no hay pedidos");
            }
            break;

        case 3:
            pedidos = Accion.CambiarEstadoPedido(pedidos);
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
            Visual.VerPedidos(pedidos);
            break;
        default:
            seguir = false;
            break;

    }
}
Accion.CalcularInforme(cadeteria);

