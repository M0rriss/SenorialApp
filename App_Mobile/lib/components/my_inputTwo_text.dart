import 'package:flutter/material.dart';

class MyInputTwoText extends StatelessWidget{
  final TextEditingController controller;
  final String hintText;  
  final bool obscureText;
  final double width;
  final double height;
  final TextAlign textAlign;

  const MyInputTwoText({
    super.key,
    required this.controller,
    required this.hintText,
    required this.obscureText,
    this.width = 65,
    this.height = 65,
    this.textAlign = TextAlign.center,   
  });

  @override
  Widget build(BuildContext context){
    return Container(
      width: width,
      height: height,
      child: TextField(
        controller: controller,
        obscureText: obscureText,
        textAlign: textAlign,
        decoration: InputDecoration(
          enabledBorder: OutlineInputBorder(
            borderSide: const BorderSide(color:  Colors.transparent),
            borderRadius: BorderRadius.circular(10),
          ),
          fillColor: const Color.fromRGBO(236, 236, 236, 1),
          filled: true,
          hintText: hintText,
          border: OutlineInputBorder(),
        )
      )
    );
  }


} 