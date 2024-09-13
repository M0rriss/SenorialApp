import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:m_senorial/components/Buttons/buttonExtras.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Buttons/buttonOrden.dart';
import 'package:m_senorial/components/Extras/productwidget.dart';
import 'package:m_senorial/components/Extras/remove_item_dialog.dart';
import 'package:m_senorial/models/Resquest/Pedido/pedido_request.dart';
import 'package:m_senorial/models/Resquest/Pedido/pedidos-request.dart';
import 'package:m_senorial/models/Resquest/Pedido/pedidosllevar-request.dart';
import 'package:m_senorial/services/pedidos/pedidos-service.dart';
import 'package:m_senorial/services/pedidosllevar/pedidosllevar_services.dart';

class OrderMenuIndoor extends StatefulWidget {
  final PedidoRequest pedido;

  const OrderMenuIndoor({
    Key? key,
    required this.pedido,
  }) : super(key: key);

  @override
  State<OrderMenuIndoor> createState() => _OrderMenuIndoorState();
}

class _OrderMenuIndoorState extends State<OrderMenuIndoor> {
  // late List<Map<String, dynamic>> products;
  double total = 0;
  List<double> precios = [];
//PEDIDOS CREACION VARIABLES
  final PedidosService pedidosService = PedidosService();
//

  @override
  void initState() {
    super.initState();
    listarProductos();
  }

  void listarProductos() {
    print('previos productps ${widget.pedido.lista.length}');
    for (var p in widget.pedido.lista) {
      total += p.precio * p.cantidad;
      precios.add(p.precio);
    }
  }

  OrdenLlevarRequest convertirParallevar(PedidoRequest pedidoRequest) {
    print("Convirtiendo a OrdenLlevarRequest...");
    double total = pedidoRequest.lista.fold(0, (sum, producto) {
      return sum + (producto.precio * producto.cantidad);
    });

    if (pedidoRequest.orden.idEmpleado == 0 ||
        pedidoRequest.orden.idTipoPedido == 0) {
      throw Exception("ID de empleado o tipo de pedido no pueden ser 0.");
    }

    List<DetallesLlevar> detalles = pedidoRequest.lista.map((producto) {
      return DetallesLlevar(
        idProducto: producto.idProducto,
        cantidad: producto.cantidad,
        precioUnitario: producto.precio,
      );
    }).toList();

    return OrdenLlevarRequest(
      idPedidoLlevar: pedidoRequest.orden.idPedido,
      idEmpleado: pedidoRequest.orden.idEmpleado,
      idCliente: pedidoRequest.orden.idCliente,
      nombreCliente: pedidoRequest.orden.nombreCliente,
      fechaPedido: DateTime.now(),
      estado: pedidoRequest.orden.estado,
      total: total.toDouble(),
      idTipoPedido: pedidoRequest.orden.idTipoPedido,
      detallesLlevar: detalles,
    );
  }

  // * IMPLEMENTACION DEL PEDIDO
  PedidosRequest convertirPedido(PedidoRequest pedidoRequest) {
    // Calcula el total antes de enviar el pedido
    print("test1");
    double total = pedidoRequest.lista.fold(0, (sum, producto) {
      return sum + (producto.precio * producto.cantidad);
    });
    print("test2");
    // Asegúrate de que estos valores no sean 0 antes de enviar el pedido
    if (pedidoRequest.orden.idEmpleado == 0) {
      throw Exception("El ID de empleado, no puede ser 0");
    }
    if (pedidoRequest.orden.idMesa == 0) {
      throw Exception("El ID de mesa,  no puede ser 0");
    }
    if (pedidoRequest.orden.idTipoPedido == 0) {
      throw Exception("El ID de tipo pedido, no puede ser 0");
    }
    print("test3");
    return PedidosRequest(
      idPedido: pedidoRequest.orden.idPedido,
      idEmpleado: pedidoRequest.orden.idEmpleado,
      idMesa: pedidoRequest.orden.idMesa,
      mesaNombre: 'Mesa ${pedidoRequest.orden.idMesa}',
      fechaPedido:
          DateTime.now(), // Ajusta la fecha a como la necesita el backend
      estado: pedidoRequest.orden.estado,
      total: total, // Ahora envía el total correcto
      idTipoPedido: pedidoRequest.orden.idTipoPedido,
      detalles: pedidoRequest.lista.map((producto) {
        return Detalle(
          idDetallePedido: producto.idDetallePedido,
          idProducto: producto.idProducto,
          productoNombre: producto.nombre,
          cantidad: producto.cantidad,
          precioUnitario: producto.precio,
        );
      }).toList(),
    );
  }

  //*PEDIDO
  Future<void> hacerPedido() async {
    try {
      if (widget.pedido.orden.idTipoPedido == 2) {
        // Si es un pedido para llevar
        OrdenLlevarRequest pedidoLlevar = convertirParallevar(widget.pedido);

        final response =
            await PedidosLlevarService().RegistrarPedido(pedidoLlevar);

        if (response.statusCode == 200 || response.statusCode == 201) {
          ScaffoldMessenger.of(context).showSnackBar(
            const SnackBar(
                content: Text('Pedido para llevar registrado con éxito')),
          );
          context.go(
              '/home/salestable/categories/productslist/ordermenuindoor/ordersuccessful');
        } else {
          ScaffoldMessenger.of(context).showSnackBar(
            const SnackBar(
                content: Text('Error al registrar el pedido para llevar')),
          );
        }
      } else {
        // Si es un pedido para comer aquí
        PedidosRequest pedido = convertirPedido(widget.pedido);

        final response = await pedidosService.RegistrarPedido(pedido);

        if (response.statusCode == 200 || response.statusCode == 201) {
          ScaffoldMessenger.of(context).showSnackBar(
            const SnackBar(content: Text('Pedido registrado con éxito')),
          );
          context.go(
              '/home/salestable/categories/productslist/ordermenuindoor/ordersuccessful');
        } else {
          ScaffoldMessenger.of(context).showSnackBar(
            const SnackBar(content: Text('Error al registrar el pedido')),
          );
        }
      }
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Error: $e')),
      );
    }
  }

  void showRemoveItemDialog(int index) {
    showModalBottomSheet(
      context: context,
      builder: (BuildContext context) {
        return RemoveItemDialog(
          onConfirm: () {
            setState(() {
              // Eliminar el producto de la lista y actualizar el total
              var productoAEliminar = widget.pedido.lista.firstWhere(
                (producto) => producto.idProducto == index,
              );
              total -= productoAEliminar.precio * productoAEliminar.cantidad;
              widget.pedido.lista.remove(productoAEliminar);
            });
          },
        );
      },
    );
  }

  void incrementarCantidad(int idProducto) {
    setState(() {
      // Buscar el índice del producto correspondiente en la lista
      var productoEncontrado = widget.pedido.lista.firstWhere(
        (p) => p.idProducto == idProducto,
      );

      if (productoEncontrado != null && productoEncontrado.cantidad < 9) {
        // Incrementar la cantidad y actualizar el precio total del producto
        productoEncontrado.cantidad++;
        productoEncontrado.precio = productoEncontrado.cantidad *
            precios[widget.pedido.lista.indexOf(productoEncontrado)];

        // Actualizar el total global
        total += precios[widget.pedido.lista.indexOf(productoEncontrado)];
      }
    });
  }

  void decrementarCantidad(int idProducto) {
    setState(() {
      // Buscar el índice del producto correspondiente en la lista
      var productoEncontrado = widget.pedido.lista.firstWhere(
        (p) => p.idProducto == idProducto,
      );

      if (productoEncontrado != null && productoEncontrado.cantidad > 1) {
        // Decrementar la cantidad y actualizar el precio total del producto
        productoEncontrado.cantidad--;
        productoEncontrado.precio = productoEncontrado.cantidad *
            precios[widget.pedido.lista.indexOf(productoEncontrado)];

        // Actualizar el total global
        total -= precios[widget.pedido.lista.indexOf(productoEncontrado)];
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const SizedBox(height: 45),
            Row(
              children: [
                const SizedBox(width: 20),
                ButtonBack(
                  onTap: () {
                    if (widget.pedido.orden.idTipoPedido == 1) {
                      // Redirigir a la lista de productos en la mesa
                      context.go('/home/salestable/categories/productslist',
                          extra: widget.pedido);
                    } else {
                      // Redirigir a la página del cliente
                      context.go(
                          '/home/takeoutregister/registerdata/categories/productslist',
                          extra: widget.pedido);
                    }
                  },
                ),
                const SizedBox(width: 20),
                const Text(
                  'PEDIDO',
                  style: TextStyle(
                    fontSize: 14.57,
                    fontWeight: FontWeight.bold,
                    color: Color.fromRGBO(252, 110, 42, 1),
                  ),
                ),
                const SizedBox(width: 222),
                UserButton(
                  onTap: () {},
                ),
              ],
            ),
            const SizedBox(height: 30),
            Row(
              children: [
                const SizedBox(width: 290),
                MyButtonExtras(
                  borderRadius: 10,
                  onTap: () {},
                  //  text: 'MESA - ${widget.pedido.orden.idMesa}',
                  text: widget.pedido.orden.idTipoPedido == 1
                      ? 'MESA - ${widget.pedido.orden.idMesa}'
                      : 'CLIENTE',
                ),
                const SizedBox(width: 20),
              ],
            ),
            const SizedBox(height: 15),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 38.0),
              child: Text(
                "Total ${widget.pedido.lista.length} artículos",
                style: const TextStyle(
                  color: Color.fromRGBO(156, 155, 166, 1),
                  fontSize: 15.7,
                  fontWeight: FontWeight.normal,
                ),
              ),
            ),
            const SizedBox(height: 16),
            for (var i in widget.pedido.lista)
              ProductWidget(
                ruta: i.ruta,
                cantidad: i.cantidad,
                productName: i.nombre,
                productPrice:i.precio, // Mostrar el precio actualizado del producto
                incremento: i.cantidad, // Mostrar la cantidad del producto
                precioInc: () {
                  incrementarCantidad(i.idProducto);
                },
                precioDec: () {
                  decrementarCantidad(i.idProducto);
                },
                onDelete: () {
                  showRemoveItemDialog(i.idProducto);
                },
              ),
            const SizedBox(height: 32),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                const Padding(
                  padding: EdgeInsets.symmetric(horizontal: 35.0),
                  child: Text(
                    'Order Subtotal',
                    style: TextStyle(
                      fontSize: 25,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 30.0),
                  child: Text(
                    'S/. ${total.toStringAsFixed(2)}',
                    style: const TextStyle(
                      fontSize: 25,
                      fontWeight: FontWeight.normal,
                    ),
                  ),
                ),
              ],
            ),
            const SizedBox(height: 25),
            if (widget.pedido.lista.isNotEmpty)
              Center(
                child: MyButtonOrdern(
                  onTap: () {
                    // Verificar el tipo de pedido antes de proceder
                    if (widget.pedido.orden.idTipoPedido == 1) {
                      // Para comer aquí
                      hacerPedido();
                    } else {
                      // Para llevar
                      hacerPedido(); // Si es diferente función, debes asegurarte de que esté definida
                    }
                  },
                  text: 'Hacer Pedido',
                  borderRadius: 10,
                  color: const Color.fromRGBO(255, 145, 15, 1),
                ),
              ),
            const SizedBox(height: 30),
          ],
        ),
      ),
    );
  }
}
