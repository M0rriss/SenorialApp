import 'package:flutter/material.dart';
// Import necesario para TextInputFormatter
import 'package:flutter/services.dart'; 
import 'package:m_senorial/components/my_button.dart';
import 'package:m_senorial/components/my_form_text.dart';
import 'package:m_senorial/components/my_input_text.dart';
import 'package:m_senorial/components/my_text_center.dart';
import 'package:m_senorial/components/my_text_title.dart';

class SignUp extends StatefulWidget {
  SignUp({super.key});

  @override
  _SignUpState createState() => _SignUpState();
}

class _SignUpState extends State<SignUp> {
  final nameController = TextEditingController();
  final dniController = TextEditingController();
  final phoneController = TextEditingController();
  final emailController = TextEditingController();
  final passwordController = TextEditingController();
  final confirmController = TextEditingController();

  @override
  void dispose() {
    nameController.dispose();
    dniController.dispose();
    phoneController.dispose();
    emailController.dispose();
    passwordController.dispose();
    confirmController.dispose();
    super.dispose();
  }

  void signUp() {
    final name = nameController.text;
    final dni = dniController.text;
    final phone = phoneController.text;
    final email = emailController.text;
    final password = passwordController.text;
    final confirmPassword = confirmController.text;

    List<String> errors = [];

    if (name.isEmpty) errors.add('Nombre');
    if (dni.isEmpty) errors.add('DNI');
    if (phone.isEmpty) errors.add('Teléfono');
    if (email.isEmpty) errors.add('Email');
    if (password.isEmpty) errors.add('Contraseña');
    if (confirmPassword.isEmpty) errors.add('Confirmar Contraseña');

    if (errors.isNotEmpty) {
      _showErrorDialog('Los siguientes campos son obligatorios:\n${errors.join(', ')}');
      return;
    }

    if (password != confirmPassword) {
      _showErrorDialog('Las contraseñas no coinciden.');
      return;
    }

    print('Name: $name');
    print('DNI: $dni');
    print('Phone: $phone');
    print('Email: $email');
    print('Password: $password');
  }

  void _showErrorDialog(String message) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Error'),
          content: Text(message),
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
      appBar: AppBar(),
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 10,),
            //title
            const MyTextTitle(contenText: 'Sign Up'),
            const SizedBox(height: 53,),
            //Sub title
            const MyTextCenter(text: 'Por favor registrese para comenzar'),
            const SizedBox(height: 30,),
            //Name
            const MyFormText(text: "Ingresa su nombre"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: nameController,
              hintText: "Mauricio Contreras",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
              inputFormatters: [
                FilteringTextInputFormatter.allow(RegExp(r"[a-zA-Z\s]")),
              ],
            ),
            const SizedBox(height: 15,),
            const MyFormText(text: "Ingresa su DNI"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: dniController,
              hintText: "71454658",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
              inputFormatters: [
                FilteringTextInputFormatter.digitsOnly,
                LengthLimitingTextInputFormatter(8),
              ],
            ),
            const SizedBox(height: 15,),
            const MyFormText(text: "Ingresa su Telefono"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: phoneController,
              hintText: "985471455",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
              inputFormatters: [
                FilteringTextInputFormatter.digitsOnly,
              ],
            ),
            const SizedBox(height: 15,),
            //Email
            const MyFormText(text: "Ingrese su Email"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: emailController,
              hintText: "example@gmail.com",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
            ),
            const SizedBox(height: 15,),
            //Password
            const MyFormText(text: "Ingrese su password"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: passwordController,
              hintText: "*********",
              obscureText: true,
              fillColor: Colors.grey[200] ?? Colors.grey,
            ),
            const SizedBox(height: 15,),
            //Confirm Password
            const MyFormText(text: "Confirme su password"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: confirmController,
              hintText: "*************",
              obscureText: true,
              fillColor: Colors.grey[200] ?? Colors.grey,
            ),
            const SizedBox(height: 21,),
            //Button
            MyButton(
              onTap: signUp,
              text: 'Sign up',
              isEnabled: true,
            ),
          ],
        ),
      ),
    );
  }
}

