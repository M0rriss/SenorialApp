import 'dart:async';

import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

class MyButtonCategories extends StatelessWidget {
  final VoidCallback? onTap;
  final String text;
  final Color? color;

  const MyButtonCategories({
    Key? key,
    required this.onTap,
    required this.text,
    this.color,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: HoverableSVG(
        svgPath: 'lib/imagenes/Subtract.svg', // Ruta a tu archivo SVG
        width: 108, // Cambia el ancho según tus necesidades
        height: 179.62, // Cambia el alto según tus necesidades
        color: color ?? const Color.fromRGBO(254, 240, 211, 1),
        text: text,
        onTap: onTap, // Pasa el onTap al HoverableSVG
      ),
    );
  }
}

class HoverableSVG extends StatefulWidget {
  final String svgPath;
  final double width;
  final double height;
  final Color color;
  final String text;
  final VoidCallback? onTap; // Añadido para permitir la acción al hacer clic

  const HoverableSVG({
    Key? key,
    required this.svgPath,
    required this.width,
    required this.height,
    required this.color,
    required this.text,
    this.onTap, // Añadido para permitir la acción al hacer clic
  }) : super(key: key);

  @override
  _HoverableSVGState createState() => _HoverableSVGState();
}

class _HoverableSVGState extends State<HoverableSVG> {
  Color _iconColor;
  bool _isClicked = false;

  _HoverableSVGState() : _iconColor = const Color.fromRGBO(254, 240, 211, 1);

  void _handleTap() {
    print('Button tapped'); // Añadido para verificar el clic
    setState(() {
      _isClicked = true;
      _iconColor = Color.fromRGBO(253, 221, 155, 1);
    });

    // Restaurar el color y estado después de un breve intervalo
    Timer(const Duration(milliseconds: 300), () {
      setState(() {
        _isClicked = false;
        _iconColor = widget.color; // Color original
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    return MouseRegion(
      onEnter: (_) {
        if (!_isClicked) {
          setState(() => _iconColor = const Color.fromARGB(255, 245, 247, 248)); // Color al pasar el mouse
        }
      },
      onExit: (_) {
        if (!_isClicked) {
          setState(() => _iconColor = widget.color); // Color al quitar el mouse
        }
      },
      child: GestureDetector(
        onTap: () {
          _handleTap();
          if (widget.onTap != null) {
            widget.onTap!(); // Asegúrate de que se llame al onTap pasado
          }
        },
        child: Column(
          children: [
            Stack(
              alignment: Alignment.center,
              children: [
                SvgPicture.asset(
                  widget.svgPath,
                  width: widget.width,
                  height: widget.height,
                  color: _iconColor,
                ),
                Positioned(
                  top: widget.height * 0.4,
                  left: 0,
                  right: 0,
                  child: Text(
                    widget.text,
                    textAlign: TextAlign.center,
                    style: const TextStyle(
                      fontSize: 14,
                      color: Color.fromRGBO(45, 52, 71, 1),
                      fontFamily: 'Roboto-Medium',
                      fontWeight: FontWeight.normal,
                    ),
                  ),
                ),
              ],
            ),
            Transform.translate(
              offset: const Offset(0, -18), // Desplaza hacia arriba
              child: Container(
                width: 37, // Ancho deseado
                height: 40.43, // Altura deseada
                decoration: const BoxDecoration(
                  color: Color.fromRGBO(24, 28, 46, 1),
                  shape: BoxShape.circle,
                ),
                child: const Center(
                  child: FaIcon(
                    FontAwesomeIcons.chevronRight,
                    color: Colors.white,
                    size: 12,
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
