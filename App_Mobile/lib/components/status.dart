import 'package:flutter/material.dart';

class StatusIndicator extends StatelessWidget {
  final String status;
  final Color color;
  /* final Color dotColor; */

  

  const StatusIndicator({
    Key? key,
    required this.status,
    required this.color, required dotColor,
    /* required this.dotColor, */
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
      decoration: BoxDecoration(
        color: color,
        borderRadius: BorderRadius.circular(30), // Aumenta la curvatura
      ),
      child: Row(
        mainAxisSize: MainAxisSize.min,
        children: [
          Container(
            width: 12,
            height: 12,
            decoration: BoxDecoration(
              shape: BoxShape.circle,
              color: Color.fromARGB(255, 121, 45, 45), // Color del punto dentro del indicador
            ),
          ),
          SizedBox(width: 8),
          Text(
            status,
            style: TextStyle(
              color: Colors.white,
              fontWeight: FontWeight.bold,
            ),
          ),
        ],
      ),
    );
  }
}

class StatusRow extends StatelessWidget {
 
   static const dotColorGrey = Color.fromRGBO(171, 174, 188, 1);
  static const dotColorRed = Colors.red;
  static const dotColorSkyBlue = Colors.blue;


  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceEvenly, // Espaciado uniforme
      children: const [
        StatusIndicator(
          status: 'Disponible',
          color: Colors.grey,
          dotColor: dotColorGrey, // Color del punto para 'Disponible'
        ),
        StatusIndicator(
          status: 'Facturado',
          color: Colors.blue,
          dotColor: dotColorSkyBlue, // Color del punto para 'Facturado'
        ),
        StatusIndicator(
          status: 'Ocupado',
          color: Colors.red,
          dotColor: dotColorRed, // Color del punto para 'Ocupado'
        ),
      ],
    );
  }
}

