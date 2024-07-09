import 'dart:async';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:m_senorial/components/my_button.dart';
import 'package:m_senorial/components/my_inputTwo_text.dart';
import 'package:m_senorial/components/my_text_center.dart';
import 'package:m_senorial/components/my_text_title.dart';
import 'package:go_router/go_router.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

class Verified extends StatefulWidget {
  Verified({super.key});

  @override
  _VerifiedState createState() => _VerifiedState();
}

class _VerifiedState extends State<Verified> {
  final TextEditingController codeController1 = TextEditingController();
  final TextEditingController codeController2 = TextEditingController();
  final TextEditingController codeController3 = TextEditingController();
  final TextEditingController codeController4 = TextEditingController();
  String Codigo = "";

  late Timer _timer;
  int _secondsRemaining = 50;
  bool _isResendEnabled = false;
  bool _areFieldsEnabled = true;

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

  @override
  void initState() {
    super.initState();
    startTimer();
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
 /*  void verified() {
    print("hola");
    context.go('/forgetpassword/recoverypassword');
     /* Navigator.pushNamed(context, '/Salestable'); */
  } */

  void Resend() {
    setState(() {
      _secondsRemaining = 50;
      _areFieldsEnabled = true;
      _isResendEnabled = false;
      FocusScope.of(context).nextFocus();
      startTimer();
    });

    // Limpiar los controladores de los códigos
    codeController1.clear();
    codeController2.clear();
    codeController3.clear();
    codeController4.clear();
  }

  void Verificado() {
    Codigo = codeController1.text + codeController2.text + codeController3.text + codeController4.text;
    print('Código ingresado: $Codigo');
    

    // Implementar la lógica para verificar el código
    if (Codigo != "1234") {
      _showErrorDialog();
    } else {
      // Código correcto, continuar con la lógica de verificación
      print('Código verificado correctamente');
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
      appBar: AppBar(),
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 10,),
            const MyTextTitle(contenText: 'Verificación'),
            const SizedBox(height: 53,),
            const MyTextCenter(text: 'Nosotros enviamos un código a su correo'),
            const SizedBox(height: 10,),
            const Text(
              'example@gmail.com',
              style: TextStyle(
                fontWeight: FontWeight.bold,
              ),
            ),
            const SizedBox(height: 60,),
            Padding(
              padding: const EdgeInsets.all(0),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  Row(
                    children: [
                      const SizedBox(width: 53,),
                      const Text(
                        "CODE",
                        style: TextStyle(
                          color: Color.fromRGBO(100, 105, 130, 1),
                          fontSize: 16,
                        ),
                      ),
                      const SizedBox(width: 153,),
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
                      const SizedBox(width: 5,),
                      Text(
                        "in $_secondsRemaining sec",
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
            const SizedBox(height: 15,),
            Row(
              children: [
                const SizedBox(width: 53,),
                MyInputTwoText(
                  allowNext: Codigo.length < 4,
                  onChangedx: () {
                    print("--->${codeController1.text}");
                    setState(() {
                      Codigo = "${codeController1.text}";
                    });
                    print("--->${Codigo}");
                  },
                  controller: codeController1,
                  hintText: "",
                  obscureText: false,
                  enable: _areFieldsEnabled,
                ),
                const SizedBox(width: 23,),
                MyInputTwoText(
                  allowNext: Codigo.length < 4,
                  onChangedx: () {
                    setState(() {
                      Codigo = "$Codigo${codeController2.text}";
                    });
                    print("--->${codeController2.text}");
                    print("--->${Codigo}");
                  },
                  controller: codeController2,
                  hintText: "",
                  obscureText: false,
                  enable: _areFieldsEnabled,
                ),
                const SizedBox(width: 23,),
                MyInputTwoText(
                  allowNext: Codigo.length < 3,
                  onChangedx: () {
                    setState(() {
                      Codigo = "$Codigo${codeController3.text}";
                    });
                    print("--->${codeController3.text}");
                    print("--->${Codigo}");
                  },
                  controller: codeController3,
                  hintText: "",
                  obscureText: false,
                  enable: _areFieldsEnabled,
                ),
                const SizedBox(width: 23,),
                MyInputTwoText(
                  allowNext: Codigo.length < 3,
                  onChangedx: () {
                    setState(() {
                      Codigo = "$Codigo${codeController4.text}";
                    });
                    print("--->${codeController4.text}");
                    print("--->${Codigo}");
                  },
                  controller: codeController4,
                  hintText: "",
                  obscureText: false,
                  enable: _areFieldsEnabled,
                ),
              ],
            ),
            const SizedBox(height: 40,),
            MyButton(
              onTap: () async {
                 context.go('/forgetpassword/recoverypassword');
                final response = await VerificarApi(Codigo);
                if (response.statusCode == 201) {
                  // If the server returns a 201 CREATED response,
                  // then parse the JSON.
                  ScaffoldMessenger.of(context).showSnackBar(
                    SnackBar(content: Text('Album created!')),
                  );
                } else {
                  // If the server did not return a 201 CREATED response,
                  // then throw an exception.
                  ScaffoldMessenger.of(context).showSnackBar(
                    SnackBar(content: Text('Failed to create album.')),
                  );
                }
              },
              isEnabled: true,
              text: 'VERIFY',
            ),
          ],
        ),
      ),
    );
  }
}
