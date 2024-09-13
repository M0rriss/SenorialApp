import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:google_fonts/google_fonts.dart';

class Buttonintems extends StatelessWidget {
  final String name;
  final String price;
  final String items;
  final String svgIconPath;
  final double width;
  final double height;
  final Color backgroundColor;
  final double borderWidth;
  final Color borderColor;

  const Buttonintems({
    Key? key,
    required this.name,
    required this.price,
    required this.items,
    required this.svgIconPath,
    this.width = 190,
    this.height = 110,
    this.backgroundColor = const Color.fromRGBO(24, 28, 46, 1),
    this.borderWidth = 2.0,
    this.borderColor = Colors.white,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        Container(
          width: width,
          height: height,
          padding: EdgeInsets.all(borderWidth), // Ajusta el padding para incluir el borde
          decoration: BoxDecoration(
            color: backgroundColor,
            borderRadius: BorderRadius.circular(8),
            border: Border.all(color: borderColor, width: borderWidth), // Agrega el borde
          ),
          child: ClipPath(
            clipper: DiagonalClipper(),
            child: Container(
              width: width,
              height: height,
              decoration: BoxDecoration(
                gradient: LinearGradient(
                  colors: [
                    Colors.white.withOpacity(0.1), // Blanco semi-transparente
                    Colors.white.withOpacity(0.0), // Transparente
                  ],
                  begin: Alignment.topCenter, // Transparencia inicia en la parte superior
                  end: Alignment.bottomCenter, // Transparencia se desvanece hacia la parte inferior
                ),
              ),
            ),
          ),
        ),
        Container(
          width: width,
          height: height,
          padding: EdgeInsets.all(borderWidth), // Ajusta el padding para incluir el borde
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Padding(
                padding: const EdgeInsets.only(left: 10.0),
                child: Text(
                  name,
                  style: GoogleFonts.assistant(
                    color: Colors.white,
                    fontSize: 30,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
              const Spacer(),
              Row(
                children: [
                  const SizedBox(width: 136),
                  SvgPicture.asset(
                    svgIconPath,
                    width: 30,
                    height: 30,
                    color: Colors.white,
                  ),
                ],
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Padding(
                    padding: const EdgeInsets.only(left: 10.0),
                    child: Text(
                      price,
                      style: GoogleFonts.assistant(
                        color: Colors.white,
                        fontSize: 15,
                        fontWeight: FontWeight.w400,
                      ),
                    ),
                  ),
                  const SizedBox(width: 50),
                  Expanded(
                    child: Align(
                      alignment: Alignment.centerLeft,
                      child: Text(
                        items,
                        style: GoogleFonts.assistant(
                          color: Colors.white,
                          fontSize: 20,
                          fontWeight: FontWeight.normal,
                        ),
                      ),
                    ),
                  ),
                ],
              ),
            ],
          ),
        ),
      ],
    );
  }
}

class DiagonalClipper extends CustomClipper<Path> {
  @override
  Path getClip(Size size) {
    Path path = Path();
    path.moveTo(0, size.height * 2.00); // Inicia desde el borde izquierdo con un ligero desplazamiento hacia abajo
    path.lineTo(size.width * 0.6, 0); // Traza la línea diagonal hacia arriba a la derecha
    path.lineTo(size.width, 0); // Llega a la esquina superior derecha
    path.lineTo(size.width, size.height); // Baja hacia la esquina inferior derecha
    path.lineTo(0, size.height); // Vuelve al punto de inicio en la esquina inferior izquierda
    path.close(); // Cierra el path
    return path;
  }

  @override
  bool shouldReclip(covariant CustomClipper<Path> oldClipper) {
    return false;
  }
}
