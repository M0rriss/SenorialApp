import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:m_senorial/components/Buttons/buttonExtras.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Buttons/buttonOrden.dart';
import 'package:m_senorial/components/Extras/productwidget.dart';
import 'package:m_senorial/components/Extras/remove_item_dialog.dart';
import 'package:m_senorial/models/Resquest/Pedido/pedido_request.dart';

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

  @override
  void initState() {
    super.initState();
    listarProductos();
  }

  void listarProductos() {
    for (var p in widget.pedido.lista) {
      total += p.precio * p.cantidad;
      precios.add(p.precio);
    }
  }

  void showRemoveItemDialog(int index) {
    showModalBottomSheet(
      context: context,
      builder: (BuildContext context) {
        return RemoveItemDialog(
          onConfirm: () {
            setState(() {
              var x = 0;
              for (var p in widget.pedido.lista) {
                if (p.idProducto == index) {
                  total -= p.precio;
                  precios.remove(x);
                  widget.pedido.lista.remove(p);
                }
              }
              // products.removeAt(index);
            });
          },
        );
      },
    );
  }

  // void incrementarCantidad(int index) {
  //   setState(() {
  //     var x = 0;
  //     for (var p in widget.pedido.lista) {
  //       if (p.cantidad == 9) {
  //         break;
  //       } else {
  //         if (p.idProducto == index) {
  //           p.cantidad++;
  //           p.precio = p.cantidad * precios[x];
  //           total = precios[x] + total;
  //         }
  //         x++;
  //       }
  //     }
  //   });
  // }

  // void decrementarCantidad(int index) {
  //   setState(() {
  //     var x = 0;
  //     for (var p in widget.pedido.lista) {
  //       if (p.cantidad == 1) {
  //         break;
  //       } else {
  //         if (p.idProducto == index) {
  //           p.cantidad--;
  //           p.precio = p.cantidad * precios[x];
  //           total = total - precios[x];
  //         }
  //         x++;
  //       }
  //     }
  //   });
  // }
void incrementarCantidad(int idProducto) {
  setState(() {
    // Buscar el índice del producto correspondiente en la lista
    var productoEncontrado = widget.pedido.lista.firstWhere(
      (p) => p.idProducto == idProducto,
      
    );

    if (productoEncontrado != null && productoEncontrado.cantidad < 9) {
      // Incrementar la cantidad y actualizar el precio total del producto
      productoEncontrado.cantidad++;
      productoEncontrado.precio = productoEncontrado.cantidad * precios[widget.pedido.lista.indexOf(productoEncontrado)];

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
      productoEncontrado.precio = productoEncontrado.cantidad * precios[widget.pedido.lista.indexOf(productoEncontrado)];

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
                    context.go('/home/salestable/categories/productslist',
                        extra: widget.pedido);
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
                  onTap: () {  },
                  //  text: 'MESA - ${widget.pedido.orden.idMesa}',
                 text: 'MESA ${widget.pedido.orden.idMesa > 0 ? widget.pedido.orden.idMesa : ''}',
                  
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
                productName: i.nombre,
                productPrice:
                    i.precio, // Mostrar el precio actualizado del producto
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
                  context.go(
                      '/home/salestable/categories/productslist/ordermenu/ordersuccessful');
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
