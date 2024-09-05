using Clases;
using Cadete_space;
using Cadeteria_space;
using Pedido_space;
using System.Runtime.Intrinsics.Arm;

List<Cadete> cadetes = LeerCSV.GenerarListaCadetes();
Cadeteria cadeteria = LeerCSV.GenerarCadeteria();
string accionS;
int accion;
int formAsig;
List<Pedido>pedidos = null;
bool seguir = true;

cadeteria.ActualizarCadetes(cadetes);
while(seguir)
{
    do
    {
        Console.WriteLine("qué acción desea hacer:\n\t1. dar de alta pedidos\n\t2. asignar pedidos a cadetes\n\t3. cambiar estado de pedido\n\t4. reasignar pedidos");
        accionS = Console.ReadLine();
    }while(!int.TryParse(accionS, out accion) || accion <= 0 || accion > 4);

    switch(accion)
    {
        case 1:
            pedidos = Accion.AgregarPedidos();
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
            }
            else
            {
                Console.WriteLine("no hay pedidos");
            }
            break;
    }
}



// Visual.VerCadetes(cadeteria);

