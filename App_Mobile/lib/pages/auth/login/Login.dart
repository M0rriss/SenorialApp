import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:m_senorial/components/my_button.dart';
import 'package:m_senorial/components/my_input_Text.dart';
import 'package:m_senorial/components/my_text_center.dart';
import 'package:m_senorial/components/my_text_title.dart';
import 'package:m_senorial/components/square_icon.dart';
class Login extends StatefulWidget {
  Login({Key? key}) : super(key: key);

  @override
  _LoginState createState() => _LoginState();
}

class _LoginState extends State<Login> {
  final emailController = TextEditingController();
  final passwordController = TextEditingController();
  bool _rememberMe = false;

  ValueNotifier<bool> isFormValid = ValueNotifier<bool>(false);

  final String validEmail = 'yairnosde@gmail.com';
  final String validPassword = 'password123';

  @override
  void initState() {
    super.initState();
    emailController.addListener(_validateForm);
    passwordController.addListener(_validateForm);
  }

  @override
  void dispose() {
    emailController.removeListener(_validateForm);
    passwordController.removeListener(_validateForm);
    emailController.dispose();
    passwordController.dispose();
    isFormValid.dispose();
    super.dispose();
  }

  void _validateForm() {
    final email = emailController.text;
    final password = passwordController.text;

    final isEmailValid = _isValidEmail(email);
    final isPasswordValid = password.isNotEmpty;

    isFormValid.value = isEmailValid && isPasswordValid;
  }

  bool _isValidEmail(String email) {
    final emailRegex = RegExp(
      r'^[^@]+@[^@]+\.[^@]+$',
    );
    return emailRegex.hasMatch(email);
  }

  void login()  {
    /* final dio = Dio();
      final response =  dio.post('https://localhost:7283/api/Auth/Login/Mobile',
          data: {'email': 'yairnosde@gmail.com', 'password': 'Mauriciogey123'});
      print(response); */
   if (emailController.text == validEmail && passwordController.text == validPassword) {
    
      print('Email: ${emailController.text}');
      print('Password: ${passwordController.text}');


      // Navigate to home screen or perform sign-in action
      context.go('/home');
    } else {
      String message = 'Correo electrónico o contraseña incorrectos';
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text(message),
          duration: Duration(seconds: 3),
        ),
      );
    } 
  }

  void signUp() {
    context.go('/signup');
  }

  void forgotPassword() {
    context.go('/forgetpassword');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 90,),
            // Title
            const MyTextTitle(contenText: "Log in"),
            const SizedBox(height: 55,),
            // Sub title
            const MyTextCenter(
              text: "Por favor ingrese con su cuenta existente"
            ),
            const SizedBox(height: 110,),
            // Title form User
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 25),
              child: Row(
                children: [
                  Text(
                    "Ingrese su Email",
                    style: TextStyle(
                      fontSize: 14,
                      color: Color.fromRGBO(100, 105, 130, 1),
                      fontWeight: FontWeight.normal,
                      fontFamily: 'Sen',
                    ),
                  )
                ],
              ),
            ),
            const SizedBox(height: 5,),
            // Input form
            MyInputText(
              controller: emailController,
              hintText: 'example@gmail.com',
              obscureText: false,
              fillColor:  Color.fromRGBO(236, 240, 244, 1),
            ),
            const SizedBox(height: 18,), 
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 25),
              child: Row(
                children: [
                  
                  Text(
                    "Ingrese su Password",
                      style: TextStyle(
                      fontSize: 14,
                      fontWeight: FontWeight.normal,
                      color:  Color.fromRGBO(100, 105, 130, 1),
                    ),
                  ),
                ],
              ),
            ),
            const SizedBox(height: 5,),
            // Password form
            MyInputText(
              controller: passwordController,
              hintText: "* * * * * * * * * *",
              obscureText: true,
              fillColor: Color.fromRGBO(236, 240, 244, 1),
            ),
            const SizedBox(height: 5,),                                                                                                                     
            // Forgot Password
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 25),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      Theme(
                        data: ThemeData(
                          checkboxTheme: CheckboxThemeData(
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(4.0),
                              side: BorderSide(color: Color.fromARGB(180, 213, 214, 209)),
                            ),
                            fillColor: MaterialStateProperty.all<Color>(Color.fromRGBO(15, 14, 14, 1)),
                          ),
                        ),
                       // Espaciado entre el checkbox y el texto
                        child: Checkbox(
                          value: _rememberMe,
                          onChanged: (bool? value) {                                                                    
                            setState(() {     
                              _rememberMe = value!;
                            });
                          },
                        ),
                      ),
                      const Text(
                        "Remember me",
                        style: TextStyle(
                          color: Color.fromRGBO(126, 138, 151, 1),
                        ),
                      ),
                    ],
                  ),
                  InkWell(
                    onTap: () => forgotPassword(),
                    child: const Text(
                      "Forgot Password",
                      style: TextStyle(
                        color: Color.fromRGBO(255, 145, 15, 1),
                      ),
                    ),
                  ),
                ],
              ),
            ),
            const SizedBox(height: 30,),
            // Login button
            ValueListenableBuilder<bool>(
              valueListenable: isFormValid,
              builder: (context, value, child) {
                return MyButton(
                  onTap: login,
                  text: "LOG IN",
                  isEnabled: value,
                );
              },
            ),
            const SizedBox(height: 27,),
            // Sign Up
            Padding(
              padding: const EdgeInsets.all(0),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Text(
                    "Don't have an account?",
                    style: TextStyle(
                      color: Color.fromRGBO(100, 105, 130, 1),
                      fontSize: 16,
                    ),
                  ),
                  const SizedBox(width: 10,),
                  InkWell(
                    onTap: () => signUp(),
                    child: const Text(
                      "SIGN UP",
                      style: TextStyle(
                        color: Color.fromRGBO(255, 118, 34, 1),
                        fontSize: 16,
                      ),
                    ),
                  ),
                ],
              ),
            ),
            const SizedBox(height: 20,),
            // Or
            const Padding(
              padding: EdgeInsets.all(0),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(
                    "Or",
                    style: TextStyle(
                      color: Color.fromRGBO(100, 105, 130, 1),
                      fontSize: 16,
                    ),
                  )
                ],
              ),
            ),
            const SizedBox(height: 10,),
            // Google icon
            const Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                SquareIcon(imagePath: 'lib/imagenes/Google.svg')
              ],
            ),
          ],
        ),
      ),
    );
  }
}