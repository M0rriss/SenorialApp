import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

class UserButton extends StatelessWidget {
  final VoidCallback onTap;
  final Color color;
  final double widthUser;
  final double heightUser;
  final bool showPencilIcon; // Nuevo parámetro para mostrar el ícono de lápiz

  const UserButton({
    Key? key,
    required this.onTap,
    this.color = const Color.fromARGB(255, 3, 3, 3),
    this.widthUser = 45.92,
    this.heightUser = 44.01,
    this.showPencilIcon = false, // Valor por defecto para no mostrar el ícono
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        SizedBox(
          width: widthUser,
          height: heightUser,
          child: ElevatedButton(
            onPressed: onTap,
            style: ButtonStyle(
              backgroundColor: MaterialStateProperty.all<Color>(color),
              padding: MaterialStateProperty.all<EdgeInsetsGeometry>(
                const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
              ),
            ),
            child: const Text(
              '',
              style: TextStyle(
                fontSize: 16,
                fontWeight: FontWeight.bold,
                color: Colors.white,
              ),
            ),
          ),
        ),
        if (showPencilIcon) // Muestra el ícono solo si showPencilIcon es true
          Positioned(
            bottom: -1,
            right: -8,
            child: Container(
              width: 75.4,
              height: 56.14,
              decoration: BoxDecoration(
                color: Colors.orange,
                shape: BoxShape.circle,
              ),
              child: const Center(
                child: FaIcon(
                  FontAwesomeIcons.pencilAlt,
                  color: Colors.white,
                  size: 20,
                ),
              ),
            ),
          ),
      ],
    );
  }
}
