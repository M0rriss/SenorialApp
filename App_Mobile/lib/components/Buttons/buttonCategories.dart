import 'dart:async';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

class MyButtonCategories extends StatelessWidget {
  final VoidCallback? onTap;
  final String text;
  final String imagePath;
  final Color? color;

  const MyButtonCategories({
    Key? key,
    required this.onTap,
    required this.text,
    required this.imagePath,
    this.color,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: HoverablePNG(
        svgPath: 'lib/imagenes/Subtract.svg', 
        pngPath: imagePath, // Ruta de la imagen PNG
        width: 108, 
        height: 179.62, 
        color: color ?? const Color.fromRGBO(254, 240, 211, 1),
        text: text,
        onTap: onTap,
      ),
    );
  }
}

class HoverablePNG extends StatefulWidget {
  final String svgPath;
  final String pngPath;
  final double width;
  final double height;
  final Color color;
  final String text;
  final VoidCallback? onTap;

  const HoverablePNG({
    Key? key,
    required this.svgPath,
    required this.pngPath,
    required this.width,
    required this.height,
    required this.color,
    required this.text,
    this.onTap,
  }) : super(key: key);

  @override
  _HoverablePNGState createState() => _HoverablePNGState();
}

class _HoverablePNGState extends State<HoverablePNG> {
  Color _iconColor;
  bool _isClicked = false;

  _HoverablePNGState() : _iconColor = const Color.fromRGBO(254, 240, 211, 1);

  void _handleTap() {
    setState(() {
      _isClicked = true;
      _iconColor = const Color.fromRGBO(253, 221, 155, 1);
    });

    Timer(const Duration(milliseconds: 300), () {
      setState(() {
        _isClicked = false;
        _iconColor = widget.color;
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    return MouseRegion(
      onEnter: (_) {
        if (!_isClicked) {
          setState(() => _iconColor = const Color.fromRGBO(254, 240, 211, 1));
        }
      },
      onExit: (_) {
        if (!_isClicked) {
          setState(() => _iconColor = widget.color);
        }
      },
      child: GestureDetector(
        onTap: () {
          _handleTap();
          if (widget.onTap != null) {
            widget.onTap!();
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
                  top: widget.height * 0.1, // Ajusta la posición vertical de la imagen PNG
                  child: Image.asset(
                    widget.pngPath,
                    width: 97, // Ajusta el ancho de la imagen PNG
                    height: 97, // Ajusta la altura de la imagen PNG
                  ),
                ),
                Positioned(
                  bottom: 50, // Ajusta la posición del texto
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
              offset: const Offset(0, -18), 
              child: Container(
                width: 37, 
                height: 40.43, 
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
