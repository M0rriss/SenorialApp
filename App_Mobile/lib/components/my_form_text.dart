import 'package:flutter/material.dart';

class MyFormText extends StatelessWidget{

  final String text;
  final double fontSize;
  const MyFormText({
    super.key,
    required this.text,
    this.fontSize = 14,
    });
  

  @override
  Widget build (BuildContext context){
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 25),
      child: Row(
        children: [
          Text(
            text,
            style: TextStyle(
              color: Color.fromRGBO(100, 105, 130, 1),
              fontSize: fontSize,
            ),
          )
        ],
      ),
      );
  }
}