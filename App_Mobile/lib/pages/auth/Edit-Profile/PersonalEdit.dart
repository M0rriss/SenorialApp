import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:m_senorial/components/Buttons/button.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Extras/my_form_text.dart';
import 'package:m_senorial/components/Inputs/my_input_text.dart';

class PersonalEdit extends StatelessWidget {
  final TextEditingController datosClienteController = TextEditingController();
  final TextEditingController phoneClienteController = TextEditingController();

  PersonalEdit({Key? key}) : super(key: key);

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
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: const [
                    Text(
                      'Edit Profile',
                      style: TextStyle(
                        fontSize: 20,
                        fontWeight: FontWeight.normal,
                        color: Color.fromRGBO(24, 28, 46, 1),
                      ),
                    ),
                  ],
                ),
              ],
            ),
            const SizedBox(height: 20),
            Center(
              child: UserButton(
                onTap: () {
                  // Acción al presionar el botón de usuario
                },
                widthUser: 182,
                heightUser: 178,
                showPencilIcon: true, // Muestra el ícono de lápiz
              ),
            ),
            const SizedBox(height: 50),
            const MyFormText(
              text: "FULL NAME",
              fontSize: 16.93, // Añadido fontSize
              fontWeight: FontWeight.normal, // Añadido fontWeight
              color: Color.fromRGBO(24, 28, 46, 1),
            ),
            const SizedBox(height: 6),
            MyInputText(

              controller: datosClienteController,
              hintText: "Felix Gloglo Lujan Carrion",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
            ),
            const SizedBox(height: 20),
            const MyFormText(
              text: "EMAIL",
              fontSize: 16.93, // Añadido fontSize
              fontWeight: FontWeight.normal, // Añadido fontWeight
              color: Color.fromRGBO(24, 28, 46, 1),
            ),
            const SizedBox(height: 6),
            MyInputText(

              controller: phoneClienteController,
              hintText: "felix@lujan.com",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
            ),
            const SizedBox(height: 20),
            const MyFormText(
              text: "PHONE NUMBER",
              fontSize: 16.93, // Añadido fontSize
              fontWeight: FontWeight.normal, // Añadido fontWeight
              color: Color.fromRGBO(24, 28, 46, 1),
            ),
            const SizedBox(height: 6),
            MyInputText(
              controller: phoneClienteController,
              hintText: "999-999-999",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
              inputFormatters: [
                FilteringTextInputFormatter.digitsOnly,
              ],
            ),
            const SizedBox(height: 40), // Añadido un SizedBox para separación
            MyButton(
              onTap: () {
                // Acción al presionar el botón
              },
              text: 'SAVE',
              fontSize: 16.78,
            ),
          ],
        ),
      ),
    );
  }
}
