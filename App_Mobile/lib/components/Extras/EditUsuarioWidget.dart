import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

class EditUsuarioWidget extends StatelessWidget {
  final String name;
  final VoidCallback onEdit;
  final double widgetEdit;
  final double heightEdit;
  final bool showLogoutIcon; // Parámetro para mostrar el ícono de logout
  final IconData? customIcon; // Parámetro para íconos personalizados

  const EditUsuarioWidget({
    Key? key,
    required this.name,
    required this.onEdit,
    this.heightEdit = 100,
    this.widgetEdit = 398,
    this.showLogoutIcon = false, // Valor por defecto para no mostrar el ícono de logout
    this.customIcon, // Ícono personalizado
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      width: widgetEdit,  
      height: heightEdit,
      margin: const EdgeInsets.all(16),
      padding: const EdgeInsets.all(16),
      decoration: BoxDecoration(
        color: const Color.fromRGBO(246, 248, 250, 1),
        borderRadius: BorderRadius.circular(19.47),
        boxShadow: [
          BoxShadow(
            color: Colors.grey.withOpacity(0.2),
            spreadRadius: 2,
            blurRadius: 8,
            offset: const Offset(0, 4),
          ),
        ],
      ),
      child: Row(
        children: [
          Container(
            width: 48.69, // Tamaño del círculo
            height: 48.69,
            decoration: BoxDecoration(
              color: Color.fromRGBO(236, 240, 244, 1), // Fondo del círculo
              shape: BoxShape.circle,
            ),
            child: Center(
              child: FaIcon(
                customIcon ?? FontAwesomeIcons.user, // Usa el ícono personalizado si se proporciona
                color: Color.fromRGBO(255, 122, 40, 1),
                size: 17.17, // Tamaño del ícono
              ),
            ),
          ),
          const SizedBox(width: 16),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                name,
                style: const TextStyle(
                  fontSize: 19.47,
                  fontWeight: FontWeight.normal,
                  color: Color.fromRGBO(24, 28, 46, 1),
                ),
              ),
              const SizedBox(height: 4),
            ],
          ),
          const Spacer(),
          IconButton(
            icon: FaIcon(
              showLogoutIcon
                  ? FontAwesomeIcons.chevronRight // Usa el ícono de flecha para logout
                  : FontAwesomeIcons.chevronRight, // Usa el ícono de flecha por defecto
              color: Color.fromRGBO(255, 122, 40, 1),
            ),
            onPressed: onEdit,
            iconSize: 17.17,
          ),
        ],
      ),
    );
  }
}
