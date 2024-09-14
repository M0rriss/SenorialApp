import 'package:flutter/material.dart';
import 'package:senorial/components/Buttons/buttonUser.dart';
import 'package:senorial/components/Buttons/buttonback.dart';
import 'package:senorial/components/Extras/DataWidget.dart';

class PersonalInfo extends StatelessWidget {
  PersonalInfo({Key? key}) : super(key: key);

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
                    // Acción al presionar el botón de regreso
                  },
                ),
                const SizedBox(width: 20),
                const Text(
                  'Personal Info',
                  style: TextStyle(
                    fontSize: 17,
                    fontWeight: FontWeight.normal,
                    color: Color.fromRGBO(24, 28, 46, 1),
                  ),
                ),
                const Spacer(), // Asegura que el texto "EDIT" esté en el extremo derecho
                Text(
                  'EDIT',
                  style: TextStyle(
                    fontSize: 14,
                    fontWeight: FontWeight.bold,
                    color: Color.fromRGBO(255, 122, 40, 1),
                    decoration: TextDecoration.underline,
                    decorationColor: Color.fromRGBO(255, 122, 40, 1),
                  ),
                ),
                const SizedBox(width: 20), // Un pequeño margen a la derecha
              ],
            ),
            const SizedBox(height: 40),
            // Mueve el UserButton más a la derecha
            Row(
              children: [
                const SizedBox(width: 65), // Espacio antes del UserButton
                UserButton(
                  onTap: () {
                    // Acción al presionar el botón de usuario
                  },
                  widthUser: 129.85,  
                  heightUser: 129.85,
                ),
                const SizedBox(width: 20), // Espacio entre el UserButton y el texto
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: const [
                    Text(
                      'Felix Lujan',
                      style: TextStyle(
                        fontSize: 26.22,
                        fontWeight: FontWeight.bold,
                        color: Color.fromRGBO(24, 28, 46, 1),
                      ),
                    ),
                  ],
                ),
              ],
            ),
            const SizedBox(height: 20),
            // Llama a DataWidget con listas de nombres y textos adicionales
            DataWidget(
              widgetEdit: 396,
              heightEdit: 234,
              names: ['FULL NAME', 'EMAIL', 'PHONE NUMBER'], // Lista de nombres
              additionalInfos: ['Felix Lujan', 'felix@lujan.com', '999-999-999'], // Lista de textos adicionales
              onEdit: () {
                // Acción al presionar el botón de editar
              },
            ),
          ],
        ),
      ),
    );
  }
}
