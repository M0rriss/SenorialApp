import 'package:flutter/material.dart';

class MyFormText extends StatelessWidget {
  final String text;
  final double fontSize;
  final Color color;
  final FontWeight fontWeight;
  final TextAlign textAlign;
  final TextOverflow textOverflow;

  const MyFormText({
    super.key,
    required this.text,
    this.fontSize = 16,
    this.color = const Color.fromRGBO(100, 105, 130, 1),
    this.fontWeight = FontWeight.normal,
    this.textAlign = TextAlign.left,
    this.textOverflow = TextOverflow.ellipsis,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 25),
      child: Row(
        children: [
          Expanded(
            child: Text(
              text,
              style: TextStyle(
                color: color,
                fontSize: fontSize,
                fontWeight: fontWeight, // Asegúrate de usar este parámetro aquí
              ),
              textAlign: textAlign,
              overflow: textOverflow,
            ),
          ),
        ],
      ),
    );
  }
}
