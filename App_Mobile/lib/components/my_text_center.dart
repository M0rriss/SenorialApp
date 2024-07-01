import 'package:flutter/material.dart';

class MyTextCenter extends StatelessWidget{
  final String text;
  final double fontSize;
  const MyTextCenter({
    super.key,
    required this.text,
    this.fontSize = 16,
    });
  @override
  Widget build (BuildContext context){
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Text(
          text,
          style: TextStyle(
            fontSize: fontSize,
            fontWeight: FontWeight.normal,
          ),
        )
      ],
    );
  }
}