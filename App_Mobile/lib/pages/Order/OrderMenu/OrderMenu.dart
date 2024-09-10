import 'package:flutter/material.dart';
import 'package:m_senorial/components/Buttons/buttonExtras.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Buttons/buttonOrden.dart';
import 'package:m_senorial/components/Extras/productwidget.dart';

class OrderMenu extends StatefulWidget {
  const OrderMenu({Key? key}) : super(key: key);

  @override
  _OrderMenuState createState() => _OrderMenuState();
}

class _OrderMenuState extends State<OrderMenu> {
  final codeController = TextEditingController();

  // Ejemplo de lista de productos con nombre y precio
  final List<Map<String, dynamic>> productos = [
    {'name': 'Hamburguesa de Pollo', 'price': 30.00},
    {'name': 'Hamburguesa de Res', 'price': 35.00},
    {'name': 'Hamburguesa Vegana', 'price': 28.00},
    {'name': 'Hamburguesa BBQ', 'price': 32.00},
  ];

  // Calcular el subtotal sumando los precios de los productos
  double calcularSubtotal() {
    return productos.fold(0.0, (total, producto) => total + producto['price']);
  }

  void goToOrderMenu() {
    Navigator.pop(context); // Vuelve a la pantalla anterior
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
                  onTap: goToOrderMenu,
                ),
                const SizedBox(width: 20),
                const Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'ORDER',
                      style: TextStyle(
                        fontSize: 14.57,
                        fontWeight: FontWeight.bold,
                        color: Color.fromRGBO(252, 110, 42, 1),
                      ),
                    ),
                    /* Text(
                      'Pedido No.16',
                      style: TextStyle(
                        fontSize: 14,
                        fontWeight: FontWeight.bold,
                        color: Color.fromRGBO(153, 153, 153, 1),
                      ),
                    ), */
                  ],
                ),
                const Spacer(),
                UserButton(
                  onTap: () {
                    // Acción cuando se presiona el botón
                  },
                ),
              ],
            ),
            const SizedBox(height: 30),
            Row(
              children: [
                const Spacer(),
                MyButtonExtras(
                  borderRadius: 10,
                  onTap: () {},
                  text: 'MESA - 1',
                ),
                const SizedBox(width: 20),
              ],
            ),
            const SizedBox(height: 10),
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 29.0),
              child: Text(
                'Total 04 artículos',
                style: TextStyle(
                  color: Color.fromRGBO(156, 155, 166, 1),
                  fontSize: 15.7,
                  fontWeight: FontWeight.normal,
                ),
              ),
            ),
            const SizedBox(height: 14),
            // Mostrar los productos en la lista
            ...productos.map((producto) {
              return Padding(
                padding: const EdgeInsets.only(bottom: 14.0),
                child: ProductWidget(
                  ruta: "",
                  productName: producto['name'],
                  productPrice: producto['price'],
                  showControls: false,
                ),
              );
            }).toList(),
            // Aquí añadimos la raya vertical centrada con borderRadius
            Center(
              child: ClipRRect(
                borderRadius: BorderRadius.circular(100), // Ajusta el borderRadius aquí
                child: Container(
                  width: 365,
                  height: 5,
                  color: const Color.fromRGBO(118, 118, 118, 1),
                  margin: const EdgeInsets.symmetric(vertical: 10),
                ),
              ),
            ),
            // Mostrar el subtotal de la orden
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
                    'S/. ${calcularSubtotal().toStringAsFixed(2)}', // Mostrar el subtotal calculado
                    style: const TextStyle(
                      fontSize: 25,
                      fontWeight: FontWeight.normal,
                    ),
                  ),
                ),
              ],
            ),
            const SizedBox(height: 40),
            Center(
              child: MyButtonOrdern(
                onTap: () {
                  // Acción cuando se presiona el botón
                },
                text: 'Hacer Pedidou',
                borderRadius: 0,
                color: const Color.fromRGBO(255, 145, 15, 1),
              ),
            ),
            const SizedBox(height: 15),
            Center(
              child: MyButtonOrdern(
                onTap: () {
                  // Acción cuando se presiona el botón
                },
                text: 'Cancelar Pedido',
                borderRadius: 0,
                color: const Color.fromRGBO(236, 40, 40, 1),
              ),
            ),
            const SizedBox(height: 20),
          ],
        ),
      ),
    );
  }
}
