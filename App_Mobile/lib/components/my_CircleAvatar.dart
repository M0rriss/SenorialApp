import 'package:flutter/material.dart';

class MyCircleAvatar extends StatelessWidget {
  final Function()? onTap;
  final String text;

  final Color? color; 

  const MyCircleAvatar({
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
        padding: const EdgeInsets.all(20),
        margin: const EdgeInsets.symmetric(horizontal: 10),
        decoration: BoxDecoration(
          color: color ?? Color.fromARGB(255, 177, 175, 174), 
          borderRadius: BorderRadius.circular(8),
        ),
        child: Stack(
          alignment: Alignment.center,
          children: [
            CircleAvatar(
              backgroundColor: Colors.white, 
              radius: 20, 
              child: Text(
                text,
                style: const TextStyle(
                  color: Color.fromARGB(255, 177, 175, 174), 
                  fontSize: 14,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
          Text(
            text,
            style: const TextStyle(
              color: Color.fromARGB(255, 159, 156, 156),
              fontSize: 14,
              fontWeight: FontWeight.bold,
            ),
          ),
          ],
        ),
      ),
    );
  }
}
