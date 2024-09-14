import 'package:flutter/material.dart';
import 'package:senorial/components/Buttons/button.dart';
import 'package:senorial/components/Buttons/buttonback.dart';
import 'package:senorial/components/Extras/my_form_text.dart';
import 'package:senorial/components/Inputs/my_input_text.dart';
import 'package:senorial/components/Texts/my_text_center.dart';
import 'package:go_router/go_router.dart';

import '../../../components/Texts/my_text_title.dart';

class ForgetPassword extends StatefulWidget {
  ForgetPassword({super.key});

  @override
  _ForgetPasswordState createState() => _ForgetPasswordState();
}

class _ForgetPasswordState extends State<ForgetPassword> {
  final gmailController = TextEditingController();
  final ValueNotifier<bool> isEmailValid = ValueNotifier<bool>(false);

  @override
  void initState() {
    super.initState();
    gmailController.addListener(_validateEmail);
  }

  @override
  void dispose() {
    gmailController.removeListener(_validateEmail);
    gmailController.dispose();
    isEmailValid.dispose();
    super.dispose();
  }

  void verified() {
    context.go('/login/forgetpassword/verified?email=${Uri.encodeComponent(gmailController.text)}');
  }

  void _validateEmail() {
    final email = gmailController.text;
    final emailRegex = RegExp(r'^[^@]+@[^@]+\.[^@]+$');
    isEmailValid.value = emailRegex.hasMatch(email);
  }

  void forgotPassword() {
    print('Email: ${gmailController.text}');
    bool emailRegistered = checkIfEmailRegistered(gmailController.text);
    
    if (!emailRegistered) {
      _showEmailNotRegisteredDialog();
    }
  }

  bool checkIfEmailRegistered(String email) {
    return email == 'yairnosde@gmail.com';
  }

  void _showEmailNotRegisteredDialog() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Correo no registrado'),
          content: Text('El correo ingresado no está registrado.'),
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
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 10),
            Container(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
              child: Row(
                children: [
                  const SizedBox(width: 5),
                  ButtonBack(
                    onTap: () {
                      Navigator.of(context).pop();
                    },
                  ),
                ],
              ),
            ),
            const SizedBox(height: 70),
             const MyTextTitle(contenText: 'Forgot Password'),
            const SizedBox(height: 15),
            const MyTextCenter(text: 'Ingrese su correo para resetear su password'),
            const SizedBox(height: 111),
            const MyFormText(text: "Ingrese su Email"),
            const SizedBox(height: 6),
            MyInputText(
              controller: gmailController,
              hintText: "example@gmail.com",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
            ),
            const SizedBox(height: 15),
            ValueListenableBuilder<bool>(
              valueListenable: isEmailValid,
              builder: (context, value, child) {
                return MyButton(
                  onTap: () => verified(),
                  text: 'SEND CODE',
                  isEnabled: value,
                );
              },
            ),
          ],
        ),
      ),
    );
  }
}
