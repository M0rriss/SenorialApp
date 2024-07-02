import 'package:flutter/material.dart';

class MyButton extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final bool isEnabled;
  final double height;
  final double width;

  const MyButton({
    Key? key,
    required this.onTap,
    required this.text,
    this.isEnabled = true,
    this.height = 62.0, // Altura por defecto
    this.width = 327, // Ancho por defecto
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
          color: isEnabled ? Color.fromARGB(255, 242, 141, 68) : Colors.grey[400],
          borderRadius: BorderRadius.circular(12),
        ),
        child: Center(
          child: Text(
            text,
            style: const TextStyle(
              color: Colors.white,
              fontSize: 14,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
      ),
    );
  }
}
