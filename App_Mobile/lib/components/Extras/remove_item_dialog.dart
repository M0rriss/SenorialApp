import 'package:flutter/material.dart';

class RemoveItemDialog extends StatelessWidget {
  final VoidCallback onConfirm;

  const RemoveItemDialog({Key? key, required this.onConfirm}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(20),
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          const Align(
            alignment: Alignment.centerLeft,
            child: Padding(
              padding: EdgeInsets.only(left: 20), // Mueve el texto 33 px a la derecha
              child: Text(
                'Remove Item?',
                style: TextStyle(
                  fontSize: 25,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
          ),
          const SizedBox(height: 10),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 20), // Añade 15 px de margen a ambos lados
            child: Align(
              alignment: Alignment.centerLeft, // Alinea el texto a la izquierda
              child: Text(
                'Estás seguro que quieres remover este ítem de la orden?',
                style: TextStyle(fontSize: 18),
              ),
            ),
          ),
          const SizedBox(height: 20),
          Column(
            children: [
              Container(
                width: 286,
                height: 45,
                decoration: BoxDecoration(
                  color: const Color.fromRGBO(255, 145, 15, 1),
                  borderRadius: BorderRadius.circular(74.59),
                ),
                child: TextButton(
                  onPressed: () {
                    onConfirm(); // Llama al callback para eliminar
                    Navigator.of(context).pop(); // Cierra el bottom sheet
                  },
                  child: const Text(
                    'Remove Item',
                    style: TextStyle(
                      fontSize: 16.13,
                      color: Colors.white,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ),
              ),
              const SizedBox(height: 10),
              TextButton(
                onPressed: () {
                  Navigator.of(context).pop(); // Cierra el bottom sheet
                },
                child: const Text(
                  'Go Back',
                  style: TextStyle(
                    fontSize: 16.13,
                    color: Color.fromRGBO(18, 18, 35, 1),
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}
