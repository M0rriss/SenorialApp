import 'package:flutter/material.dart';
import 'package:m_senorial/components/my_button.dart';
import 'package:m_senorial/components/my_form_text.dart';
import 'package:m_senorial/components/my_input_Text.dart';
import 'package:m_senorial/components/my_text_center.dart';
import 'package:m_senorial/components/my_text_title.dart';

class Recoverypassword extends StatefulWidget {
  Recoverypassword({super.key});

  @override
  _RecoverypasswordState createState() => _RecoverypasswordState();
}

class _RecoverypasswordState extends State<Recoverypassword> {
  final nuevopasswordController = TextEditingController();
  final confirmPasswordController = TextEditingController();
  bool _isButtonEnabled = false;

  @override
  void initState() {
    super.initState();
    nuevopasswordController.addListener(_validatePasswords);
    confirmPasswordController.addListener(_validatePasswords);
    // Initial validation to ensure the button is disabled at start
    _validatePasswords();
  }

  void _validatePasswords() {
    setState(() {
      _isButtonEnabled = nuevopasswordController.text.isNotEmpty &&
          confirmPasswordController.text.isNotEmpty;
    });
  }

  void signUp() {
    // Imprimir las contraseñas en la consola
    print('Nueva contraseña: ${nuevopasswordController.text}');
    print('Confirmar contraseña: ${confirmPasswordController.text}');

    // Verificar si las contraseñas coinciden
    if (nuevopasswordController.text != confirmPasswordController.text) {
      _showErrorDialog();
    } else {
      // Implementar la lógica de registro aquí
      print('Contraseñas coinciden. Continuar con la lógica de registro.');
    }
  }

  void _showErrorDialog() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Error'),
          content: Text('Las contraseñas no coinciden.'),
          actions: <Widget>[
            TextButton(
              child: Text('OK'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }

  @override
  void dispose() {
    nuevopasswordController.dispose();
    confirmPasswordController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 10,),
            // Title
            const MyTextTitle(contenText: 'Cambio de Contraseña'),
            const SizedBox(height: 53,),
            // Sub title
            const MyTextCenter(text: 'Por favor ingrese su nueva contraseña'),
            const SizedBox(height: 25,),
            // New Password
            const MyFormText(text: "Ingrese su contraseña"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: nuevopasswordController,
              hintText: "* * * * * * * * * *",
              obscureText: true,
              fillColor: Colors.grey[200] ?? Colors.grey,
            ),
            const SizedBox(height: 21,),
            // Confirm Password
            const MyFormText(text: "Confirme su contraseña"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: confirmPasswordController,
              hintText: "* * * * * * * * * *",
              obscureText: true,
              fillColor: Colors.grey[200] ?? Colors.grey,
            ),  
            const SizedBox(height: 21,),
            // Button
            MyButton(
              onTap: _isButtonEnabled ? signUp : null,
              text: 'SAVE CHANGES',
              isEnabled: _isButtonEnabled,
            ),
          ],
        ),
      ),
    );
  }
}
