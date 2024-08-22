import 'package:flutter/material.dart';

class StatusIndicator extends StatelessWidget {
  final String status;
  final Color color;
  final Color dotColor;
  final double containerWidth;
  final double containerHeight;

  const StatusIndicator({
    Key? key,
    required this.status,
    required this.color,
    required this.dotColor,
    this.containerWidth = 90.0,
    this.containerHeight = 22.09,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      width: containerWidth,
      height: containerHeight,
      decoration: BoxDecoration(
        color: color,
        borderRadius: BorderRadius.circular(containerHeight / 2), // Ajusta la curvatura según la altura del contenedor
      ),
      child: Row(
        mainAxisSize: MainAxisSize.min,
        mainAxisAlignment: MainAxisAlignment.center,
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          SizedBox(width: 2.0),
          Container(
            width: 18.09,
            height: 18.09,
            decoration: BoxDecoration(
              shape: BoxShape.circle,
              color: dotColor,
            ),
          ),
          Flexible(
            child: Padding(
              padding: const EdgeInsets.only(right: 4.0), // Ajusta el padding a la derecha del texto
              child: Center(
                child: Text(
                  status,
                  textAlign: TextAlign.center,
                  style: TextStyle(
                    fontSize: 10, // Tamaño de fuente reducido
                    color: Color.fromARGB(255, 3, 3, 3),
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

class StatusRow extends StatelessWidget {
  static const dotColorGrey = Color.fromRGBO(171, 174, 188, 1);
  static const dotColorSkyBlue = Color.fromRGBO(119, 152, 238, 1 );
  static const dotColorRed = Color.fromRGBO(241, 115, 115, 1 );
  

 @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center, // Centra los indicadores horizontalmente
      children: const [
        StatusIndicator(
          status: 'Disponible',
          color: Color.fromARGB(225, 225, 225, 225),
          dotColor: dotColorGrey,
          containerWidth: 90.0,
          containerHeight: 22.09,
        ),
        SizedBox(width: 5), // Ajusta el espacio entre los indicadores
        StatusIndicator(
          status: 'Facturado',
          color: Color.fromARGB(225, 225, 225, 225),
          dotColor: dotColorSkyBlue,
          containerWidth: 90.0,
          containerHeight: 22.09,
        ),
        SizedBox(width: 5), // Ajusta el espacio entre los indicadores
        StatusIndicator(
          status: 'Ocupado',
          color: Color.fromARGB(225, 225, 225, 225),
          dotColor: dotColorRed,
          containerWidth: 90.0,
          containerHeight: 22.09,
        ),
      ],
    );
  }
}