import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

class DataWidget extends StatelessWidget {
  final List<String> names; // Lista de nombres
  final List<String> additionalInfos; // Lista de textos adicionales
  final VoidCallback onEdit;
  final double widgetEdit;
  final double heightEdit;

  const DataWidget({
    Key? key,
    required this.names,
    required this.additionalInfos,
    required this.onEdit,
    this.heightEdit = 100,
    this.widgetEdit = 398,
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
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center, // Centra verticalmente
        crossAxisAlignment: CrossAxisAlignment.center, // Centra horizontalmente
        children: List.generate(
          3,
          (index) {
            IconData iconData;
            switch (index) {
              case 0:
                iconData = FontAwesomeIcons.user; // Ícono de usuario
                break;
              case 1:
                iconData = FontAwesomeIcons.envelope; // Ícono de correo
                break;
              case 2:
                iconData = FontAwesomeIcons.phone; // Ícono de teléfono
                break;
              default:
                iconData = FontAwesomeIcons.question; // Ícono predeterminado
            }
            return Padding(
              padding: EdgeInsets.only(bottom: index < 2 ? 16 : 0), // Añade espacio solo entre los elementos, no al final
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center, // Centra horizontalmente
                children: [
                  Container(
                    width: 48.69, // Tamaño del círculo
                    height: 48.69,
                    decoration: const BoxDecoration(
                      color: Color.fromRGBO(236, 240, 244, 1), // Fondo del círculo
                      shape: BoxShape.circle,
                    ),
                    child: Center(
                      child: FaIcon(
                        iconData, // Usa el ícono seleccionado
                        color: const Color.fromRGBO(255, 122, 40, 1),
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
                        names[index], // Usa el texto del índice actual
                        style: const TextStyle(
                          fontSize: 17.04,
                          fontWeight: FontWeight.normal,
                          color: Color.fromRGBO(24, 28, 46, 1),
                        ),
                      ),
                      const SizedBox(height: 4),
                      Text(
                        additionalInfos[index], // Usa el texto adicional del índice actual
                        style: const TextStyle(
                          fontSize: 17.04,
                          fontWeight: FontWeight.normal,
                          color: Color.fromRGBO(144, 152, 166, 1), // Color para el texto adicional
                        ),
                      ),
                    ],
                  ),
                  const Spacer(),
                ],
              ),
            );
          },
        ),
      ),
    );
  }
}

