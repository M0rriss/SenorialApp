import 'package:flutter/material.dart';
import 'package:m_senorial/components/Buttons/buttonExtras.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Buttons/buttonOrden.dart';
import 'package:m_senorial/components/Extras/productwidget.dart';

class OrderMenu extends StatelessWidget {
  OrderMenu({Key? key}) : super(key: key);

  final codeController = TextEditingController();

  void mesas() {}

  @override
  Widget build(BuildContext context) {
    void OrderMenu() {
      Navigator.pushNamed(context, '/OrderMenu');
    }

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
                    OrderMenu();
                  },
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
                    Text(
                      'Pedido No.16',
                      style: TextStyle(
                        fontSize: 14,
                        fontWeight: FontWeight.bold,
                        color: Color.fromRGBO(153, 153, 153, 1),
                      ),
                    ),
                  ],
                ),
                const SizedBox(width: 198),
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
                const SizedBox(width: 289),
                MyButtonExtras(
                  borderRadius: 10,
                  onTap: () {},
                  text: 'MESA - 1',
                ),
              ],
            ),
            const SizedBox(height: 10),
            const Row(
              children: [
                SizedBox(width: 29),
                Text(
                  'Total 04 artículos',
                  style: TextStyle(
                    color: Color.fromRGBO(156, 155, 166, 1),
                    fontSize: 15.7,
                    fontWeight: FontWeight.normal,
                  ),
                ),
              ],
            ),
            const SizedBox(height: 14),
            ProductWidget(showControls: false), // Usa la versión sin controles
            const SizedBox(height: 14),
            ProductWidget(showControls: false), // Usa la versión sin controles
            const SizedBox(height: 14),
            ProductWidget(showControls: false), // Usa la versión sin controles
            const SizedBox(height: 14),
            ProductWidget(showControls: false), // Usa la versión sin controles
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
            // Aquí añadimos el texto y la suma entre ProductWidget y MyButtonOrdern
            const Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Padding(
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
                  padding: EdgeInsets.symmetric(horizontal: 30.0),
                  child: Text(
                    'S/.120.00', // Aquí deberías calcular la suma real de los productos
                    style: TextStyle(
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
                text: 'Hacer Pedido',
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
                text: 'Hacer Pedido',
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
