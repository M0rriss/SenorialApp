import 'package:flutter/material.dart';

class MyButtonList extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final String additionalText;
  final String extraText;
  final Color? color;

  const MyButtonList({
    Key? key,
    required this.onTap,
    required this.text,
    required this.additionalText,
    required this.extraText,
    this.color,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        width: 150,
        height: 200,
        padding: const EdgeInsets.all(10),
        margin: const EdgeInsets.symmetric(horizontal: 15),
        decoration: BoxDecoration(
          color: color ?? Color.fromARGB(255, 177, 175, 174),
          borderRadius: BorderRadius.circular(8),
        ),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: [
            SizedBox(height: 70,),
            Text(
              text,
              style: const TextStyle(
                fontSize: 16,
                fontWeight: FontWeight.bold,
                color: Colors.black, 
              ),
            ),
            Text(
              additionalText,
              style: const TextStyle(
                color: Color.fromARGB(255, 21, 20, 20),
                fontSize: 12,
              ),
            ),
            Row(
              children:[
            Text(
              extraText,
              style: const TextStyle(
                color: Color.fromARGB(255, 228, 137, 84),
                fontSize: 12,
              ),
            ),
            SizedBox(width: 60),
             MyCircleAvatar(
              onTap: onTap,
            ),
          ],
         )
        ]
      ),
     ),
   );
  }
}
class MyCircleAvatar extends StatelessWidget {
  final Function()? onTap;
  const MyCircleAvatar({
    Key? key,
    required this.onTap,
  }) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Column(
        children: [
          CircleAvatar(
            backgroundColor: Color.fromARGB(255, 228, 137, 84),
            radius: 12,
            child: SizedBox.shrink(), 
          ),
        ],
      ),
    );
  }
}





