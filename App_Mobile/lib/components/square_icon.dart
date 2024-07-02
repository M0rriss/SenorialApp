import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart'; // Importa flutter_svg

class SquareIcon extends StatelessWidget {
  final String imagePath;

  const SquareIcon({Key? key, required this.imagePath}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(10),
      child: SvgPicture.asset(
        imagePath,
        height: 82,
        width: 82,
      ),
    );
  }
}
