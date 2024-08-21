import 'package:flutter/material.dart';

class MyButtonOrdern extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final Color? color;
  final double borderRadius;
  final double widthllevar;
  final double heightllevar;

  const MyButtonOrdern({
    Key? key,
    required this.onTap,
    required this.text,
    required this.borderRadius,
    this.widthllevar = 286,
    this.heightllevar = 44,
    this.color,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        width: widthllevar,
        height: heightllevar,
        padding: const EdgeInsets.symmetric(horizontal: 20),
        decoration: BoxDecoration(
          color: color ?? const Color.fromARGB(255, 177, 175, 174),
          borderRadius: BorderRadius.circular(74.59),
        ),
        child: Center(
          child: Text(
            text,
            style: const TextStyle(
              color: Colors.white,
              fontSize: 16.13,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
      ),
    );
  }
}
