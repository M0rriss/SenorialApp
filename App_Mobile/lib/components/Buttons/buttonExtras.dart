import 'package:flutter/material.dart';

class MyButtonExtras extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final Color? color;
  final double borderRadius;

  const MyButtonExtras({
    Key? key,
    required this.onTap,
    required this.text,
    required this.borderRadius,
    this.color,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        width: 118, // Ajusta el ancho según sea necesario
        height: 31, // Ajusta la altura según sea necesario
        padding: const EdgeInsets.symmetric(horizontal: 19), // Ajusta el padding según sea necesario
        decoration: BoxDecoration(
          color: const Color.fromRGBO(254, 242, 215, 1),
          borderRadius: BorderRadius.circular(8.9),
        ),
        child: Row(
          children: [
            Container(
              width: 20,
              height: 20,
              decoration: BoxDecoration(
                color: const Color.fromRGBO(254, 242, 215, 1),
                borderRadius: BorderRadius.circular(4), // Bordes redondeados para el contenedor
              ),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      _buildSquare(),
                      _buildSquare(),
                    ],
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      _buildSquare(),
                      _buildSquare(),
                    ],
                  ),
                ],
              ),
            ),
            const SizedBox(width: 8), // Espacio entre el icono y el texto
            Text(
              text,
              style: const TextStyle(
                color: Color.fromRGBO(18, 18, 35, 1), // Color del texto
                fontSize: 11.64,
                fontWeight: FontWeight.bold,
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildSquare() {
    return Container(
      width: 9, // Ancho del cuadrado
      height: 9, // Alto del cuadrado
      decoration: BoxDecoration(
        color: const Color.fromARGB(255, 18, 18, 35), // Color del vector cuadrado
        borderRadius: BorderRadius.circular(3.5), // Bordes redondeados para cada cuadrado
      ),
    );
  }
}
