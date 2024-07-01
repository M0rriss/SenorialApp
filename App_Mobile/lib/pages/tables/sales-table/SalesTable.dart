import 'package:flutter/material.dart';
import 'package:m_senorial/components/my_buttonTwo.dart';
import 'package:m_senorial/components/my_buttonTables.dart'; // Verifica esta importación
import 'package:m_senorial/components/my_circularbutton.dart'; // Verifica esta importación
import 'package:m_senorial/components/status.dart'; // Verifica esta importación

class Salestable extends StatefulWidget {
  Salestable({Key? key}) : super(key: key);

  @override
  _SalestableState createState() => _SalestableState();
}

class _SalestableState extends State<Salestable> {
  final codeController = TextEditingController();
  List<int> mesas = [1]; // Lista inicial de mesas

  void agregarMesa() {
    setState(() {
      mesas.add(mesas.length + 1); // Agregar una nueva mesa con el siguiente número
    });
  }

  void Tables() {
    Navigator.pushNamed(context, '/Salestable');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Row(
              children: [
                SizedBox(width: 20),
                MyCircularButton(
                  onTap: () {
                    Tables();
                  },
                  text: '',
                  diameter: 50,
                ),
                SizedBox(width: 20),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Ventas',
                      style: TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.bold,
                        color: Color.fromARGB(255, 228, 129, 15),
                      ),
                    ),
                    SizedBox(height: 0),
                    Text(
                      'Mauricio',
                      style: TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ],
                ),
                SizedBox(width: 100),
                my_buttonTwo(
                  buttonback: 12,
                  onTap: () {
                    Tables();
                  },
                  text: 'Mesas',
                  color: Color.fromARGB(255, 236, 152, 57),
                ),
                MyCircularButton(
                  onTap: () {
                    Tables();
                  },
                  text: '',
                  diameter: 50,
                ),
              ],
            ),
            SizedBox(height: 20),
            StatusRow(), // Verifica esta clase y su importación
            SizedBox(height: 90),
            Center(
              child: Padding(
                padding: const EdgeInsets.all(2.0,), // Ajusta el padding según necesites
                child: GridView.builder(
                  shrinkWrap: true, // Añadir esta línea para evitar problemas de scroll dentro de SingleChildScrollView
                  physics: NeverScrollableScrollPhysics(), // Para evitar problemas de desplazamiento
                  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                    crossAxisCount: 3, // Número de columnas
                    crossAxisSpacing: 1, // Espaciado horizontal entre los elementos
                    mainAxisSpacing: 1, // Espaciado vertical entre los elementos
                    childAspectRatio: (1.2/0.7),
                  ),
                  itemCount: mesas.length + 1, // Añade uno para el botón de agregar mesa
                  itemBuilder: (BuildContext context, int index) {
                    if (index < mesas.length) {
                      return My_ButtonTables(
                        onTap: () {
                          // Lógica de onTap aquí
                        },
                        text: mesas[index].toString(), // Número de la mesa
                        color: Color.fromRGBO(254, 240, 211, 1),
                        status: '3',
                        statusColor: Color.fromRGBO(171, 174, 188, 1),
                      );
                    } else {
                      return My_ButtonTables(
                        onAddMesa: agregarMesa,
                        onTap: () {},
                        color: Color.fromRGBO(254, 240, 211, 1),
                        status: '',
                        statusColor: Colors.transparent,
                        text: '',
                      );
                    }
                  },
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
