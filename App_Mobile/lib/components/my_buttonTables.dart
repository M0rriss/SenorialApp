import 'package:flutter/material.dart';

class My_ButtonTables extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final Color? color;
  final String status; // Añade un nuevo parámetro para el estado
  final Color statusColor; // Añade un nuevo parámetro para el color del estado
  final Function()? onAddMesa; // Función para manejar la acción de agregar mesa

  const My_ButtonTables({
    Key? key,
    required this.onTap,
    required this.text,
    this.color,
    required this.status, // Haz que el estado sea requerido
    required this.statusColor, // Haz que el color del estado sea requerido
    this.onAddMesa,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Stack(
        alignment: Alignment.topRight,
        children: [
          Container(
            width: 90,
            height: 60,
            padding: const EdgeInsets.all(10),
            margin: const EdgeInsets.symmetric(horizontal: 20),
            decoration: BoxDecoration(
              color: color ?? Colors.grey,
              borderRadius: BorderRadius.circular(8),
            ),
            child: Center(
              child: Text(
                text,
                style: const TextStyle(
                  color: Color.fromARGB(255, 25, 77, 59),
                  fontSize: 14,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
          ),
          // Añade un indicador de estado en la esquina superior derecha
          Positioned(
            top: 5,
            right: 85, // Ajusta el valor para mover el indicador de estado más a la izquierda
            child: Container(
              width: 15,
              height: 15,
              decoration: BoxDecoration(
                shape: BoxShape.circle,
                color: statusColor,
              ),
              child: Center(
                child: Text(
                  status,
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 10,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
            ),
          ),
          // Botón para agregar mesa
          if (onAddMesa != null)
            Positioned(
              top: 5,
              right: 40,
              child: IconButton(
                icon: Icon(Icons.add),
                onPressed: onAddMesa,
              ),
            ),
        ],
      ),
    );
  }
}