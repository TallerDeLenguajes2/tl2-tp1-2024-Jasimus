# 2.a
La relación entre el cliente y el pedido se hace por _composición_. El pedido existe antes que el cliente, y el cliente empieza a existir por la existencia de un pedido.
La relación entre el pedido y el cadete se hace por _agregación_. El cadete existe antes que el pedido, y el pedido se lo pasa al cadete como parámetro.
La relación entre el cadete y la cadetería se hace por _agregación_. La cadetería existe antes que el cadete, y los cadetes se los pasa como parámetro.

La clase Cadetería debería tener un método _AsignarCadete_, que tome como parámetro una lista de pedidos y elija los cadetes del ListadoCadetes para cumplir con la entrega de algún pedido; debería tener un método _ActualizarCadetes_, que tome como parámetro un listado de cadetes y lo reasigne al campo _ListadoCadetes_.
La clase Cadete debería tener un método _TomarPedido_, que tome como parámetro un pedido y lo agrega a la lista de pedidos a entregar de ese cadete, y otro método _PedidoEntregado_ que elimine del listado de <ins>pedidos</ins> del cadete el pedido entregado.

## Campos públicos:
### Cadete
* Nombre
* Id
* Teléfono

### Cadetería
* Nombre
* Teléfono

### Pedidos
* Estado

### Cliente
* Nombre
* Dirección
* Teléfono
* DatosReferenciaDirección

## Métodos Públicos
### Cadete
* JornalACobrar()
* PedidoEntregado()
* TomarPedido()

### Pedidos
* VerDireccionCliente()
* VerDatosClientes()

## Constructores
Cadeteria(string nombre, string tel)
Cadete(int id, string nombre, string direccion, string tel)
pedidos(int nro, string obs, string nombreCliente, string dirCliente, string telCliente, string datosReferenciaDireccion)
cliente(string nombre, string direccion, string datosReferenciaDireccion)


## Curiosidad de Linq
El método _Find_ de **IEnumerable** devuelve una referencia a un elemento de la instancia a la que se lo aplica. (No probé, pero me imagino que será igual con los demás métodos: la devolución de una referencia y no de una copia).