import 'package:flutter/material.dart';

class MyTextTitle extends StatelessWidget{
  final String contenText;
  final double fontSize;
  const MyTextTitle ({super.key, required this.contenText,this.fontSize = 28});
  @override
  Widget build (BuildContext context){
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Text(
          contenText,
          style: TextStyle(
            fontSize: fontSize,
            fontWeight: FontWeight.bold,
            fontFamily: 'Poppins',
          ),
        ),
      ],
    );    
  }
}