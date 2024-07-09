import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart'; // Importa flutter_svg

class SquareIcon extends StatelessWidget {
  final String imagePath;

  const SquareIcon({Key? key, required this.imagePath}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(10),
      child: _buildImage(imagePath),
    );
  }

  Widget _buildImage(String imagePath) {
    if (imagePath.endsWith('.svg')) {
      return SvgPicture.asset(
        imagePath,
        height: 82,
        width: 82,
      );
    } else if (imagePath.endsWith('.png')) {
      return Image.asset(
        imagePath,
        height: 132,
        width: 140,
      );
    } else if (imagePath.endsWith('.jpg')) {
      return Image.asset(
        imagePath,
        height: 132,
        width: 140,
      );
    } else {
      return const SizedBox.shrink(); // Devuelve un widget vacío si el formato no es soportado
    }
  }
}
