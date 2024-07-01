import 'package:flutter/material.dart';
import 'package:m_senorial/components/my_button.dart';
import 'package:m_senorial/components/my_form_text.dart';
import 'package:m_senorial/components/my_input_Text.dart';
import 'package:m_senorial/components/my_text_center.dart';
import 'package:m_senorial/components/my_text_title.dart';

class SignUp extends StatelessWidget {
  SignUp({super.key});

  final nameController = TextEditingController();
  final gmailController = TextEditingController();
  final passwordController = TextEditingController();
  final confirmController = TextEditingController();

  void signUp() {}

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 74,),
            //title
            const MyTextTitle(contenText: 'Sign Up'),
            const SizedBox(height: 53,),
            //Sub title
            const MyTextCenter(text: 'Por favor registrese para comenzar'),
            const SizedBox(height: 111,),
            //Form
            //Name
            const MyFormText(text: "Ingresa su nombre"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: nameController,
              hintText: "Mauricio Contreras",
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey, // Proporcionar el color de relleno
            ),
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
            const SizedBox(height: 21,),
            //Password
            const MyFormText(text: "Ingrese su password"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: passwordController,
              hintText: "*********",
              obscureText: true,
              fillColor: Colors.grey[200] ?? Colors.grey, // Proporcionar el color de relleno
            ),
            const SizedBox(height: 21,),
            //Confirm Password
            const MyFormText(text: "Confirme su password"),
            const SizedBox(height: 6,), 
            MyInputText(
              controller: confirmController,
              hintText: "*************",
              obscureText: true,
              fillColor: Colors.grey[200] ?? Colors.grey, // Proporcionar el color de relleno
            ),
            const SizedBox(height: 21,),
            //Button
            MyButton(onTap: signUp, text: 'Sign In'),
          ],
        ),
      ),
    );
  }
}