import 'package:flutter/material.dart';

class MyButton extends StatelessWidget {
  final VoidCallback? onTap;
  final String text;
  final bool isEnabled;
  final double height;
  final double width;
  final double fontSize;

  const MyButton({
    Key? key,
    required this.onTap,
    required this.text,
    this.isEnabled = true,
    this.height = 62.0, // Altura por defecto
    this.width = 327.0, // Ancho por defecto
    this.fontSize = 14.0,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: isEnabled ? onTap : null,
      child: Container(
        padding: const EdgeInsets.all(20),
        margin: const EdgeInsets.symmetric(horizontal: 62),
        height: height,
        width: width,
        decoration: BoxDecoration(
          color: isEnabled
              ? Color.fromARGB(255, 242, 141, 68)
              : Colors.grey[400] ?? Colors.grey, // Asegurarse de que no sea nulo
          borderRadius: BorderRadius.circular(12),
        ),
        child: Center(
          child: Text(
            text,
            style: TextStyle(
              color: Colors.white,
              fontWeight: FontWeight.bold,
              fontSize: fontSize,
            ),
          ),
        ),
      ),
    );
  }
}
