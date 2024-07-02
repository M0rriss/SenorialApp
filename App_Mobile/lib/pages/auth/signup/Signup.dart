import 'package:flutter/material.dart';
import 'package:flutter/services.dart'; // Import necesario para TextInputFormatter
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
  bool _isButtonEnabled = false;

  @override
  void initState() {
    super.initState();
    nameController.addListener(_validateForm);
    dniController.addListener(_validateForm);
    phoneController.addListener(_validateForm);
    emailController.addListener(_validateForm);
    passwordController.addListener(_validateForm);
    confirmController.addListener(_validateForm);
    _validateForm(); // Initial validation
  }

  void _validateForm() {
    setState(() {
      _isButtonEnabled = _isNameValid(nameController.text) &&
          _isDniValid(dniController.text) &&
          _isPhoneValid(phoneController.text) &&
          _isEmailValid(emailController.text) &&
          _arePasswordsValid(passwordController.text, confirmController.text);
    });
  }

  bool _isNameValid(String name) {
    return RegExp(r'^[a-zA-Z\s]+$').hasMatch(name);
  }

  bool _isDniValid(String dni) {
    return RegExp(r'^\d{1,8}$').hasMatch(dni);
  }

  bool _isPhoneValid(String phone) {
    return RegExp(r'^\d+$').hasMatch(phone);
  }

  bool _isEmailValid(String email) {
    return RegExp(r'^[^@\s]+@[^@\s]+\.[^@\s]+$').hasMatch(email);
  }

  bool _arePasswordsValid(String password, String confirmPassword) {
    return password.isNotEmpty && password == confirmPassword;
  }

  void signUp() {
    // Implement your sign up logic here
  }

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
                FilteringTextInputFormatter.allow(RegExp("[a-zA-Z]"))
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
              onTap: _isButtonEnabled ? signUp : null,
              text: 'Sign In',
              isEnabled: _isButtonEnabled,
            ),
          ],
        ),
      ),
    );
  }
}
