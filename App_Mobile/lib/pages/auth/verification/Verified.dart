import 'dart:async';
import 'package:flutter/material.dart';
import 'package:m_senorial/components/Buttons/button.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Inputs/my_inputTwo_text.dart';
import 'package:m_senorial/components/Texts/my_text_center.dart';
import 'package:m_senorial/components/Texts/my_text_title.dart';
import 'package:go_router/go_router.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

class Verified extends StatefulWidget {
  Verified({super.key});

  @override
  _VerifiedState createState() => _VerifiedState();
}

class _VerifiedState extends State<Verified> {
  String? email;
  late Timer _timer;
  int _secondsRemaining = 50;
  bool _isResendEnabled = false;
  bool _areFieldsEnabled = true;

  final TextEditingController codeController1 = TextEditingController();
  final TextEditingController codeController2 = TextEditingController();
  final TextEditingController codeController3 = TextEditingController();
  final TextEditingController codeController4 = TextEditingController();

  String Codigo = '1234';

  @override
  void initState() {
    super.initState();
    startTimer();
    
    WidgetsBinding.instance.addPostFrameCallback((_) {
      final state = GoRouterState.of(context);
      setState(() {
        email = state.uri.queryParameters['email'];
      });
    });
  }

  @override
  void dispose() {
    _timer.cancel();
    codeController1.dispose();
    codeController2.dispose();
    codeController3.dispose();
    codeController4.dispose();
    super.dispose();
  }

  void startTimer() {
    _timer = Timer.periodic(const Duration(seconds: 1), (timer) {
      setState(() {
        if (_secondsRemaining > 0) {
          _secondsRemaining--;
        } else {
          _areFieldsEnabled = false;
          _isResendEnabled = true;
          _timer.cancel();
        }
      });
    });
  }

  void Resend() {
    setState(() {
      _secondsRemaining = 50;
      _areFieldsEnabled = true;
      _isResendEnabled = false;
      FocusScope.of(context).nextFocus();
      startTimer();
    });

    codeController1.clear();
    codeController2.clear();
    codeController3.clear();
    codeController4.clear();
  }

  void Verificado() {
    Codigo = codeController1.text + codeController2.text + codeController3.text + codeController4.text;
    print('Código ingresado: $Codigo');

    if (Codigo == "1234") {
      print('Código verificado correctamente');
      // Navegar a la pantalla de Recoverypassword
      context.go('/login/forgetpassword/recoverypassword');
    } else {
      _showErrorDialog();
    }
  }

  void _showErrorDialog() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Código incorrecto'),
          content: Text('El código ingresado es incorrecto.'),
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

  Future<http.Response> VerificarApi(String title) {
    return http.put(
      Uri.parse('https://localhost:7283/api/Auth/RecoveryPassword/movil'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(<String, String>{
        'title': title,
      }),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 42),
            Container(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
              child: Row(
                children: [
                  const SizedBox(width: 17),
                  ButtonBack(
                    onTap: () {
                      Navigator.of(context).pop();
                    },
                  ),
                  const SizedBox(width: 70),
                ],
              ),
            ),
            const SizedBox(height: 10),
            const MyTextTitle(contenText: 'Verificación'),
            const SizedBox(height: 53),
            const MyTextCenter(text: 'Nosotros enviamos un código a su correo'),
            const SizedBox(height: 10),
            Text(
              email ?? 'example@gmail.com',
              style: TextStyle(
                fontWeight: FontWeight.bold,
              ),
            ),
            const SizedBox(height: 60),
            Padding(
              padding: const EdgeInsets.all(0),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  Row(
                    children: [
                      const SizedBox(width: 53),
                      const Text(
                        "CODE",
                        style: TextStyle(
                          color: Color.fromRGBO(100, 105, 130, 1),
                          fontSize: 16,
                        ),
                      ),
                      const SizedBox(width: 153),
                      InkWell(
                        onTap: _isResendEnabled ? Resend : null,
                        child: Text(
                          "Resend",
                          style: TextStyle(
                            color: _isResendEnabled ? Colors.blue : Colors.grey,
                            fontSize: 16,
                            decoration: TextDecoration.underline,
                          ),
                        ),
                      ),
                      const SizedBox(width: 5),
                      Text(
                        "in $_secondsRemaining",
                        style: const TextStyle(
                          color: Color.fromRGBO(100, 105, 130, 1),
                          fontSize: 16,
                        ),
                      ),
                    ],
                  ),
                ],
              ),
            ),
            const SizedBox(height: 20),
            Row(
              children: [
                const SizedBox(width: 53),
                MyInputTwoText(
                  allowNext: Codigo.length < 4,
                  onChangedx: () {
                    setState(() {
                      Codigo = "${codeController1.text}";
                    });
                  },
                  controller: codeController1,
                  hintText: "",
                  obscureText: false,
                  enable: _areFieldsEnabled,
                ),
                const SizedBox(width: 23),
                MyInputTwoText(
                  allowNext: Codigo.length < 4,
                  onChangedx: () {
                    setState(() {
                      Codigo = "$Codigo${codeController2.text}";
                    });
                  },
                  controller: codeController2,
                  hintText: "",
                  obscureText: false,
                  enable: _areFieldsEnabled,
                ),
                const SizedBox(width: 23),
                MyInputTwoText(
                  allowNext: Codigo.length < 3,
                  onChangedx: () {
                    setState(() {
                      Codigo = "$Codigo${codeController3.text}";
                    });
                  },
                  controller: codeController3,
                  hintText: "",
                  obscureText: false,
                  enable: _areFieldsEnabled,
                ),
                const SizedBox(width: 23),
                MyInputTwoText(
                  allowNext: Codigo.length < 3,
                  onChangedx: () {
                    setState(() {
                      Codigo = "$Codigo${codeController4.text}";
                    });
                  },
                  controller: codeController4,
                  hintText: "",
                  obscureText: false,
                  enable: _areFieldsEnabled,
                ),
              ],
            ),
            const SizedBox(height: 100),
            MyButton(
              onTap: Verificado,
              text: 'VERIFY',
              isEnabled: _areFieldsEnabled,
            ),
          ],
        ),
      ),
    );
  }
}
