import 'package:flutter/material.dart';
import 'package:flutter/services.dart'; // Import necesario para TextInputFormatter

class MyInputTwoText extends StatelessWidget {
  final TextEditingController controller;
  final Function()? onChangedx;
  final String hintText;
  final bool obscureText;
  final double width;
  final double height;
  final bool allowNext;
  final TextAlign textAlign;
  final List<TextInputFormatter>? inputFormatters;
  final bool enable;

  const MyInputTwoText({
    Key? key,
    required this.controller,
    required this.onChangedx,
    required this.hintText,
    required this.obscureText,
    this.width = 62,
    this.height = 61.26,
    required this.allowNext,
    this.textAlign = TextAlign.center,
    this.inputFormatters,
    this.enable = true,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      width: width,
      height: height,
      child: TextField(
        controller: controller,
        obscureText: obscureText,
        textAlign: textAlign,
        maxLength: 1, // Limita la longitud del campo a 1 carácter
        keyboardType: TextInputType.number, // Establece el teclado numérico
        inputFormatters: [
          FilteringTextInputFormatter.digitsOnly, // Acepta solo dígitos
          ...?inputFormatters, // Añade otros formateadores si existen
        ],
        enabled: enable,
        decoration: InputDecoration(
          enabledBorder: OutlineInputBorder(
            borderSide: const BorderSide(color: Color.fromARGB(0, 64, 49, 113)),
            borderRadius: BorderRadius.circular(12),
          ),
          filled: true,
          hintText: hintText,
          counterText: '', // Oculta el contador de caracteres
          border: OutlineInputBorder(),
        ),
        onChanged: (value) {
          print("--->$allowNext ${value.length}");
          if (allowNext && value.length == 1){
            FocusScope.of(context).nextFocus();
          }
            if (allowNext && value.length == 0){
            FocusScope.of(context).previousFocus();
          }
          onChangedx!();
        },
      ),
    );
  }
}



