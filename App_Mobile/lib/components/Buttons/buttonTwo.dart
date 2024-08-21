import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class MyButtonTwo extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final double buttonWidth;
  final double buttonHeight;
  final double buttonRadius;
  final double fontSize;
  final Color color;
  final IconData? icon;

  const MyButtonTwo({
    Key? key,
    required this.onTap,
    required this.text,
    this.buttonWidth = 78,
    this.buttonHeight = 40,
    this.buttonRadius = 12,
    this.fontSize = 18,
    this.color = Colors.blue,
    this.icon,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        width: buttonWidth,
        height: buttonHeight,
        padding: const EdgeInsets.all(5),
        margin: const EdgeInsets.symmetric(horizontal: 20),
        decoration: BoxDecoration(
          color: color,
          borderRadius: BorderRadius.circular(buttonRadius),
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            if (icon != null) ...[
              Icon(
                icon,
                color: Colors.white,
                size: fontSize * 1.2,
              ),
              const SizedBox(width: 8),
            ],
            Text(
              text,
              style: GoogleFonts.assistant(
                color: Colors.white,
                fontSize: fontSize,
                fontWeight: FontWeight.bold,
              ),
            ),
          ],
        ),
      ),
    );
  }
}
