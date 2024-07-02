import 'dart:async';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:m_senorial/components/my_button.dart';
import 'package:m_senorial/components/my_inputTwo_text.dart';
import 'package:m_senorial/components/my_text_center.dart';
import 'package:m_senorial/components/my_text_title.dart';

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
    // Implementar la lógica para verificar el código
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
                  hintText: "a",
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
                  },
                  controller: codeController2,
                  hintText: "b",
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
                  },
                  controller: codeController3,
                  hintText: "c",
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
                  },
                  controller: codeController4,
                  hintText: "d",
                  obscureText: false,
                  enable: _areFieldsEnabled,
                ),
              ],
            ),
            const SizedBox(height: 40,),
            MyButton(
               onTap: () {       
                print("hola");      
               print(Codigo);
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