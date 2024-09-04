import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:google_fonts/google_fonts.dart';

class ButtonList extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final String additionalText;
  final String extraText;
  final Color? color;
  final IconData? icon;
  final Function()? onIconTap; // Añadir función para manejar clic en el ícono
  final String imageProduc; // Añadir un parámetro para la URL de la imagen

  const ButtonList({
    Key? key,
    required this.onTap,
    required this.text,
    required this.additionalText,
    required this.extraText,
    this.color,
    this.icon,
    this.onIconTap, // Añadir parámetro para función de clic en ícono
    required this.imageProduc, // Añadir parámetro para la URL de la imagen
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        width: 162.58,
        height: 216.44,
        padding: const EdgeInsets.all(10),
        margin: const EdgeInsets.symmetric(horizontal: 15),
        decoration: BoxDecoration(
          color: color ?? const Color.fromRGBO(255, 255, 255, 1),
          borderRadius: BorderRadius.circular(10.49),
          boxShadow: [
            BoxShadow(
              color: Colors.black.withOpacity(0.2),
              spreadRadius: 2,
              blurRadius: 5,
              offset: const Offset(0, 4),
            ),
          ],
        ),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: [
            Image.network(
              imageProduc, // Usa la URL de la imagen pasada
              width: 110.14, 
              height: 72.14,
            ),
            const SizedBox(height: 8),
            Text(
              text,
              style: const TextStyle(
                fontSize: 16,
                fontWeight: FontWeight.bold,
                color: Colors.black,
              ),
            ),
            Text(
              additionalText,
              style: const TextStyle(
                color: Color.fromARGB(255, 21, 20, 20),
                fontSize: 12.59,
              ),
            ),
            const SizedBox(height: 5),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  extraText,
                  style: GoogleFonts.dmSans(
                    textStyle: const TextStyle(
                      color: Color.fromARGB(255, 228, 137, 84),
                      fontWeight: FontWeight.bold,
                      fontSize: 14,
                    ),
                  ),
                ),
                Container(
                  width: 25.17,
                  height: 25.17,
                  decoration: const BoxDecoration(
                    color: Colors.orange,
                    shape: BoxShape.circle,
                  ),
                  child: IconButton(
                    icon: Icon(
                      icon ?? FontAwesomeIcons.plus,  // Usa el ícono pasado o un valor predeterminado
                      color: Colors.white,
                      size: 22,
                    ),
                    onPressed: () {
                      print('Icon clicked'); // Imprime mensaje al hacer clic en el ícono
                      if (onIconTap != null) {
                        onIconTap!(); // Asegúrate de que se llame al onIconTap pasado
                      }
                    },
                    padding: EdgeInsets.zero,
                    constraints: const BoxConstraints(),
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
