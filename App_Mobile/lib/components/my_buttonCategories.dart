import 'package:flutter/material.dart';

class my_buttonCategories extends StatelessWidget {
  final Function()? onTap;
  final String text;

  final Color? color; 

  const my_buttonCategories({
    Key? key,
    required this.onTap,
    required this.text,
    this.color, 
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
    
      onTap: onTap,
      child: Container(
        width: 85,
        height: 85,
        padding: const EdgeInsets.all(10),
        margin: const EdgeInsets.symmetric(horizontal: 1),
        decoration: BoxDecoration(
          color: color ?? Color.fromARGB(255, 177, 175, 174), 
          borderRadius: BorderRadius.circular(8),
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
