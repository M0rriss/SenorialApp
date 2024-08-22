import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class ButtonTables extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final Color? color;
  final String status;
  final Color statusColor;
  final Function()? onAddMesa;
  final double width;
  final double height;

  const ButtonTables({
    Key? key,
    required this.onTap,
    required this.text,
    this.color,
    required this.status,
    required this.statusColor,
    this.onAddMesa,
    this.width = 74,
    this.height = 60,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        width: width,
        height: height,
        margin: const EdgeInsets.all(4.0),
        decoration: BoxDecoration(
          color: color,
          borderRadius: BorderRadius.circular(10),
        ),
        child: Stack(
          children: [
            Center(
              child: Text(
                text,
                style: GoogleFonts.assistant(
                  color: Colors.black,
                  fontSize: 16,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            if (onAddMesa == null)
              Positioned(
                left: 5,
                bottom: 5,
                child: Row(
                  children: [
                    Text(
                      status,
                      style: const TextStyle(
                        color: Colors.black,
                        fontSize: 10,
                      ),
                    ),
                    const SizedBox(width: 12), // Ajuste el espacio entre el texto y el ícono
                    const Icon(
                      Icons.person,
                      color: Colors.black,
                      size: 12,
                    ),
                  ],
                ),
              ),
            Positioned(
              top: 5,
              right: 55,
              child: Container(
                width: 8,
                height: 8,
                decoration: BoxDecoration(
                  shape: BoxShape.circle,
                  color: statusColor,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
