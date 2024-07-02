import 'package:flutter/material.dart';
import 'package:m_senorial/components/my_button.dart';
import 'package:m_senorial/components/my_form_text.dart';
import 'package:m_senorial/components/my_input_Text.dart';
import 'package:m_senorial/components/my_text_center.dart';
import 'package:m_senorial/components/my_text_title.dart';

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

  void _validateEmail() {
    final email = gmailController.text;
    final emailRegex = RegExp(r'^[^@]+@[^@]+\.[^@]+$');
    isEmailValid.value = emailRegex.hasMatch(email);
  }

  void forgotPassword() {
    
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 15),
            // Title
            const MyTextTitle(contenText: 'Forgot Password'),
            const SizedBox(height: 53,),
            // Sub title
            const MyTextCenter(text: 'Ingrese su correo para resetear su password'),
            const SizedBox(height: 111,),
            // Form
            const MyFormText(text: "Ingrese su Email"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: gmailController,
              hintText: "example@gmail.com",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
            ),
            const SizedBox(height: 15,),
            // Button
            ValueListenableBuilder<bool>(
              valueListenable: isEmailValid,
              builder: (context, value, child) {
                return MyButton(
                  onTap: value ? forgotPassword : null, // Enable/Disable the button
                  text: 'SEND CODE',
                  isEnabled: value, // Pasar el estado de habilitado
                );
              },
            ),
          ],
        ),
      ),
    );
  }
}

