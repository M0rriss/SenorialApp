import 'package:flutter/material.dart';

class RemoveItemDialog extends StatelessWidget {
  const RemoveItemDialog({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(20),
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          Align(
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
          SizedBox(height: 10),
          Padding(
            padding: EdgeInsets.symmetric(horizontal: 20), // Añade 15 px de margen a ambos lados
            child: Align(
              alignment: Alignment.centerLeft, // Alinea el texto a la izquierda
              child: Text(
                'Estás seguro que quieres remover este ítem de la orden?',
                style: TextStyle(fontSize: 18),
              ),
            ),
          ),
          SizedBox(height: 20),
          Column(
            children: [
              Container(
                width: 286,
                height: 45,
                decoration: BoxDecoration(
                  color: Color.fromRGBO(255, 145, 15, 1),
                  borderRadius: BorderRadius.circular(74.59),
                ),
                child: TextButton(
                  onPressed: () {
                    // Realiza la acción de eliminar
                    Navigator.of(context).pop(); // Cierra el bottom sheet
                  },
                  child: Text(
                    'Remove Item',
                    style: TextStyle(
                      fontSize: 16.13,
                      color: Colors.white,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ),
              ),
              SizedBox(height: 10),
              TextButton(
                onPressed: () {
                  Navigator.of(context).pop(); // Cierra el bottom sheet
                },
                child: Text(
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
