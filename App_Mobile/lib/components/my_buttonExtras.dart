import 'package:flutter/material.dart';

class MyButtonExtras extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final Color? color;
  final double borderRadius;



  const MyButtonExtras({
    Key? key,
    required this.onTap,
    required this.text,
    required this.borderRadius,

    this.color,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        width: 180,
        height: 36,
        padding: const EdgeInsets.symmetric(horizontal: 20),
        decoration: BoxDecoration(
          color: color ?? Color.fromARGB(255, 177, 175, 174),
          borderRadius: BorderRadius.circular(borderRadius),
        ),
        child: Row(
          children: [
            CircleAvatar(
              backgroundColor: Color.fromARGB(255, 255, 255, 255),
              radius: 8,
              child: Center(
              child: Text(
                '+',
                style: TextStyle(
                  color: const Color.fromARGB(255, 230, 138, 32),
                  fontSize: 11,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
          ),
            SizedBox(width: 20),
            Text(
              text,
              style: const TextStyle(
                color: Colors.white,
                fontSize: 13,
                fontWeight: FontWeight.bold,
              ),
            ),
          ],
        ),
      ),
    );
  }
}
