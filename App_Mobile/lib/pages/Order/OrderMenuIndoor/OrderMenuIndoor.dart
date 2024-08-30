import 'package:flutter/material.dart';
import 'package:m_senorial/components/Buttons/buttonExtras.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Buttons/buttonOrden.dart';
import 'package:m_senorial/components/Extras/productwidget.dart';
import 'package:m_senorial/components/Extras/remove_item_dialog.dart'; // Importa el nuevo widget

class OrderMenuIndoor extends StatelessWidget {
  final List<Map<String, dynamic>> selectedProducts; // Almacena los productos seleccionados con nombre y precio

  OrderMenuIndoor({Key? key, required this.selectedProducts}) : super(key: key);

  final codeController = TextEditingController();

  void showRemoveItemDialog(BuildContext context) {
    showModalBottomSheet(
      context: context,
      builder: (BuildContext context) {
        return RemoveItemDialog(); // Usa el nuevo widget
      },
    );
  }

  // Calcula el total sumando los precios de los productos seleccionados
  double calcularTotal() {
    return selectedProducts.fold(0, (sum, item) => sum + item['precio']);
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
                    Navigator.of(context).pop();
                  },
                ),
                const SizedBox(width: 20),
                const Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'PEDIDO',
                      style: TextStyle(
                        fontSize: 14.57,
                        fontWeight: FontWeight.bold,
                        color: Color.fromRGBO(252, 110, 42, 1),
                      ),
                    ),
                    Text(
                      'Pedido No.16', // Aquí podrías personalizar el número de pedido si es necesario
                      style: TextStyle(
                        fontSize: 14,
                        fontWeight: FontWeight.bold,
                        color: Color.fromRGBO(153, 153, 153, 1),
                      ),
                    ),
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
              ],
            ),
            const SizedBox(height: 15),
            Text(
              'Total ${selectedProducts.length} artículos', // Muestra la cantidad de productos
              style: const TextStyle(
                color: Color.fromRGBO(156, 155, 166, 1),
                fontSize: 15.7,
                fontWeight: FontWeight.normal,
              ),
            ),
            const SizedBox(height: 16),
            for (var producto in selectedProducts)
              ProductWidget(
                productName: producto['nombre'],
                productPrice: 'S/. ${producto['precio'].toStringAsFixed(2)}', // Muestra el precio del producto
                onDelete: () {
                  showRemoveItemDialog(context);
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
                    'S/. ${calcularTotal().toStringAsFixed(2)}', // Muestra el total calculado
                    style: const TextStyle(
                      fontSize: 25,
                      fontWeight: FontWeight.normal,
                    ),
                  ),
                ),
              ],
            ),
            const SizedBox(height: 25),
           Center(
  child: MyButtonOrdern(
    onTap: () {
      // Acción cuando se presiona el botón 'Hacer Pedido'
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
