import 'package:flutter/material.dart';

class my_buttonTwo extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final double buttonback;
  final Color? color; 

  const my_buttonTwo({
    Key? key,
    required this.onTap,
    required this.text,
    required this.buttonback,
    this.color, 
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        padding: const EdgeInsets.all(10),
        margin: const EdgeInsets.symmetric(horizontal: 20),
        decoration: BoxDecoration(
          color: color ?? Color.fromARGB(255, 177, 175, 174), 
          borderRadius: BorderRadius.circular(buttonback),
        ),
        child: Center(
          child: Text(
            text,
            style: const TextStyle(
              color: Colors.white,
              fontSize: 14,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
      ),
    );
  }
}
