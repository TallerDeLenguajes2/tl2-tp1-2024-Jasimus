# 2.a
La relación entre el cliente y el pedido se hace por _composición_. El pedido existe antes que el cliente, y el cliente empieza a existir por la existencia de un pedido.
La relación entre el pedido y el cadete se hace por _agregación_. El cadete existe antes que el pedido, y el pedido se lo pasa al cadete como parámetro.

La clase Cadetería debería tener un método _AsignarCadete_, que tome como parámetro una lista de pedidos y elija los cadetes del ListadoCadetes para cumplir con la entrega de algún pedido.
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


