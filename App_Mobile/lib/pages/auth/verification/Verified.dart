import 'package:flutter/material.dart';
import 'package:m_senorial/components/my_button.dart';
import 'package:m_senorial/components/my_inputTwo_text.dart';
import 'package:m_senorial/components/my_text_center.dart';
import 'package:m_senorial/components/my_text_title.dart';

class Verified extends StatelessWidget{
  Verified({super.key});
  final codeController = TextEditingController();
   // ignore: non_constant_identifier_names
   void Verificado(){
    //Navigator.pushNamed(context, '/Verificado');
   }
  @override
  Widget build(BuildContext context){

  void Resend() {
      Navigator.pushNamed(context, '/Resend');
    }

    return Scaffold(
      appBar: AppBar(),
      body: SingleChildScrollView ( child: Column(
        children: [
          const SizedBox(height: 74,),
          //title
          const MyTextTitle(contenText: 'Verificación'),
          const SizedBox(height: 53,),
          //Sub title
          const MyTextCenter(text: 'Nosotros enviamos un código a su correo'),
          const SizedBox(height: 10,),
          //Email
          Text('example@gmail.com',
          style: TextStyle(
            fontWeight: FontWeight.bold,
          ),
          ),
          const SizedBox(height: 100,
          ),
           Padding(
            
            padding: const EdgeInsets.all(0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const Text(
                  "CODE",
                  style: TextStyle(
                    color: Color.fromRGBO(100, 105, 130, 1),
                    fontSize: 16,
                  ),
                ),
                const SizedBox(width: 165,),
                InkWell(
                  onTap: () => Resend(),
                  child: const Text(
                    "Resend",
                    style: TextStyle(
                      color: Color.fromRGBO(0, 0, 0, 1),
                      fontSize: 16,
                      decoration: TextDecoration.underline,
                    ),
                    ),
                ), 
                const SizedBox(width: 5,),
                 const Text(
                  "in.50sec",
                  style: TextStyle(
                    color: Color.fromRGBO(100, 105, 130, 1),
                    fontSize: 16,
                  ),
                ),
              ],
            ),
          ),
            //Verified of code
          Row(
          children: [
            SizedBox(width: 64,),
            MyInputTwoText(
              controller: codeController,
              hintText: "6",
                    
              obscureText: false,
            ),
            SizedBox(width: 22,),
            MyInputTwoText(
              controller: codeController,
              hintText: "0",
              obscureText: false,
            ), 
            SizedBox(width: 22,),
            MyInputTwoText(
              controller: codeController,
              hintText: "8",
              obscureText: false,
            ), 
            SizedBox(width: 22,),
            MyInputTwoText(
              controller: codeController,
              hintText: "5",
              obscureText: false,
            ),         
  ],
),
          //Button
          const SizedBox(height: 40,
          ),
          MyButton(onTap: Verificado,  text: 'VERIFY',
          
          ),        
        ],
      ),
      ),
    );
  }
}