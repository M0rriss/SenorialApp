import 'package:flutter/material.dart';
import 'package:m_senorial/components/my_button.dart';
import 'package:m_senorial/components/my_form_text.dart';
import 'package:m_senorial/components/my_input_Text.dart';
import 'package:m_senorial/components/my_text_center.dart';
import 'package:m_senorial/components/my_text_title.dart';

class ForgetPassword extends StatelessWidget {
  ForgetPassword({super.key});

  final gmailController = TextEditingController();

  void forgotPassword() {
    //Navigator.pushNamed(context, '/forgetpassword');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 74,),
            //title
            const MyTextTitle(contenText: 'Forgot Password'),
            const SizedBox(height: 53,),
            //Sub title
            const MyTextCenter(text: 'Ingrese su correo para resetear su password'),
            const SizedBox(height: 111,),
            //Form
            const SizedBox(height: 21,),
            //Email
            const MyFormText(text: "Ingrese su Email"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: gmailController,
              hintText: "example@gmail.com",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey, // Proporcionar el color de relleno
            ),
            const SizedBox(height: 6,),
            //Button
            MyButton(onTap: forgotPassword, text: 'Send Code'),
          ],
        ),
      ),
    );
  }
}
