import 'package:flutter/material.dart';
import 'package:flutter/services.dart'; // Necesario para los inputFormatters
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:go_router/go_router.dart';
import 'package:m_senorial/components/Buttons/buttonOrden.dart';
import 'package:m_senorial/components/Buttons/buttonTwo.dart'; 
import 'package:m_senorial/components/Extras/my_form_text.dart';
import 'package:m_senorial/components/Inputs/my_input_text.dart';
import 'package:m_senorial/components/Texts/my_text_center.dart';

class RegisterData extends StatefulWidget {
  RegisterData({super.key});

  @override
  _RegisterDataState createState() => _RegisterDataState();
}

class _RegisterDataState extends State<RegisterData> {
  final TextEditingController DatosCleinteController = TextEditingController();
  final TextEditingController phoneclienteController = TextEditingController();
  final TextEditingController DniClienteController = TextEditingController();

  bool value = true; // Variable para habilitar o deshabilitar el botón "GUARDAR"

  void cancel() {
    // Acción al presionar el texto "Cancelar"
    Navigator.pop(context); // Vuelve a la pantalla anteriorS
  }

   void navGuardar(BuildContext context) {
  context.go('/home/takeoutregister/registerdata/categories');
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 70),
            const Text(
              'Pedido para llevar',
              style: TextStyle(
                fontSize: 28,
                fontWeight: FontWeight.bold,
              ),
            ),
            const SizedBox(height: 30),
            const MyTextCenter(text: 'Por favor ingrese sus datos del cliente'),
            const SizedBox(height: 40),
            const MyFormText(text: "Ingresar DNI del cliente"),
            const SizedBox(height: 6),
            Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                MyInputText(
                  width: 219.37,
                  height: 57,
                  controller: DniClienteController,
                  hintText: "71742345",
                  obscureText: false,
                  fillColor: Colors.grey[200] ?? Colors.grey,
                ),
                const SizedBox(width: 8), // Espacio entre el input y el botón
                MyButtonTwo(
                  onTap: () {
                    // Acción al presionar el botón de "Buscar"
                  },
                  text: 'Buscar',
                  color: const Color.fromRGBO(255, 145, 15, 1),
                  buttonWidth: 95,
                  buttonHeight: 40,
                  fontSize: 17.5,
                  icon: FontAwesomeIcons.magnifyingGlass, // Ícono de búsqueda
                ),
              ],
            ),
            const SizedBox(height: 50),
            const MyFormText(text: "Nombres y Apellidos"),
            const SizedBox(height: 6),
            MyInputText(
              controller: DatosCleinteController,
              hintText: "Felix Gloglo Lujan Carrion",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
              inputFormatters: [
                FilteringTextInputFormatter.singleLineFormatter,
              ],
            ),
            const SizedBox(height: 10),
            const MyFormText(text: "Teléfono (opcional)"),
            const SizedBox(height: 6),
            MyInputText(
              controller: phoneclienteController,
              hintText: "985471455",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
              inputFormatters: [
                FilteringTextInputFormatter.digitsOnly,
              ],
            ),
            const SizedBox(height: 55),
             MyButtonOrdern(
                onTap: () => navGuardar(context),
                text: 'Guardar',
                borderRadius: 10,
                widthllevar: 120.39,
                heightllevar: 45,
                color: Color.fromRGBO(255, 145, 15, 1),
              ),
            const SizedBox(height: 20),
            GestureDetector(
              onTap: cancel,
              child: const Text(
                'Cancelar',
                style: TextStyle(
                  color: Color.fromRGBO(18, 18, 35, 1 ),
                  fontSize: 16,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
