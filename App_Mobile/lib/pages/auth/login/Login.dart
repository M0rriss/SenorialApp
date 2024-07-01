import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:m_senorial/components/my_button.dart';
import 'package:m_senorial/components/my_input_Text.dart';
import 'package:m_senorial/components/my_text_center.dart';
import 'package:m_senorial/components/my_text_title.dart';
import 'package:m_senorial/components/square_icon.dart';

class Login extends StatefulWidget {
  Login({super.key});

  @override
  _LoginState createState() => _LoginState();
}

class _LoginState extends State<Login> {
  final usernameController = TextEditingController();
  final passwordController = TextEditingController();
  bool _rememberMe = false;

  @override
  Widget build(BuildContext context) {
    void signIn() {
      context.go('/home');
    }

    void signUpIn() {
      context.go('/signup');
    }

    void forgotPassword() {
      context.go('/forgotpassword');
    }

    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 110,),
            // Title
            const MyTextTitle(contenText: "Login In"),
            const SizedBox(height: 55,),
            // Sub title
            const MyTextCenter(
              text: "Por favor ingrese con su cuenta existente"
            ),
            const SizedBox(height: 100,),
            // Title form User
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 25),
              child: Row(
                children: [
                  Text(
                    "Ingrese su Email",
                    style: TextStyle(
                      fontSize: 16,
                      color: Color.fromRGBO(8, 13, 37, 1),
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
              controller: usernameController,
              hintText: 'example@gmail.com',
              obscureText: false,
              fillColor: Colors.grey[200] ?? Colors.grey,
            ),
            const SizedBox(height: 24,),
            // Title password form
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 25),
              child: Row(
                children: [
                  Text(
                    "Ingrese su Password",
                    style: TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.normal,
                      color: Color.fromRGBO(100, 105, 130, 1),
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
              fillColor: Colors.grey[200] ?? Color.fromARGB(255, 224, 224, 224),
            ),
            const SizedBox(height: 25,),
            // Forgot Password
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 25),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Row(
                    children: [
                      Theme(
                        data: ThemeData(
                          checkboxTheme: CheckboxThemeData(
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(4.0),
                              side: BorderSide(color: Color.fromARGB(180, 213, 214, 209)),
                            ),
                            fillColor: MaterialStateProperty.all<Color>(Color.fromRGBO(15, 14, 14, 1)), // Color del checkbox
                          ),
                        ),
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
            const SizedBox(height: 40,),
            // Login button
            MyButton(onTap: signIn, text: "Sign In"),
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
                    onTap: () => signUpIn(),
                    child: const Text(
                      "SING UP",
                      style: TextStyle(
                        color: Color.fromRGBO(255, 118, 34, 1),
                        fontSize: 16,
                      ),
                    ),
                  ),
                ],
              ),
            ),
            const SizedBox(height: 24,),
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
            const SizedBox(height: 24,),
            // Google icon
            const Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                SquareIcon(imagePath: 'lib/imagenes/google.png')
              ],
            ),
          ],
        ),
      ),
    );
  }
}
