import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class CustomButton extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final double buttonWidth;
  final double buttonHeight;
  final double buttonRadius;
  final Color color;
  final int? badgeNumber; // Número a mostrar en el círculo

  const CustomButton({
    Key? key,
    required this.onTap,
    required this.text,
    this.buttonWidth = 81.44, // Ancho por defecto, ajustable según necesidad
    this.buttonHeight = 40, // Alto por defecto, ajustable según necesidad
    this.buttonRadius = 12, // Radio de borde por defecto, ajustable según necesidad
    this.color = Colors.blue, // Color de fondo por defecto
    this.badgeNumber, // Número a mostrar en el círculo (opcional)
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Stack(
        clipBehavior: Clip.none, // Asegúrate de que el círculo pueda salirse del contenedor si es necesario
        children: [
          Container(
            width: buttonWidth,
            height: buttonHeight,
            padding: const EdgeInsets.all(5),
            margin: const EdgeInsets.symmetric(horizontal: 20),
            decoration: BoxDecoration(
              color: color,
              borderRadius: BorderRadius.circular(buttonRadius),
            ),
            child: Center(
              child: Text(
                text,
                style: GoogleFonts.assistant(
                  color: Colors.white,
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
          ),
          if (badgeNumber != null) 
            Positioned(
              top: -4, // Ajusta la posición vertical del círculo
              right: 17, // Ajusta la posición horizontal del círculo
              child: Container(
                width: 19.44, // Ancho del círculo
                height: 19.44, // Alto del círculo
                decoration: BoxDecoration(
                  color: Color.fromRGBO(23, 1, 29, 1),
                  shape: BoxShape.circle,
                ),
                child: Center(
                  child: Text(
                    badgeNumber.toString(),
                    style: const TextStyle(
                      color: Colors.white,
                      fontSize: 13.89,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ),
              ),
            ),
        ],
      ),
    );
  }
}
