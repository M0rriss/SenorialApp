import 'package:flutter/material.dart';

class MyButtonOrdern extends StatelessWidget {
  final Function()? onTap;
  final String text;
  final Color? color;
  final double borderRadius;
  final Widget additionalText;



  const MyButtonOrdern({
    Key? key,
    required this.onTap,
    required this.text,
    required this.borderRadius,
    required this.additionalText,

    this.color,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        width: 340,
        height: 40,
        padding: const EdgeInsets.symmetric(horizontal: 20),
        decoration: BoxDecoration(
          color: color ?? Color.fromARGB(255, 177, 175, 174),
          borderRadius: BorderRadius.circular(borderRadius),
        ),
        child: Row(
          children: [
            Column(
              children: [
              additionalText,
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
            SizedBox(width: 125),
            ElevatedButton(
             onPressed: () {},
             style: ElevatedButton.styleFrom(
             //primary: Color.fromARGB(255, 255, 255, 255),
             minimumSize: Size(120, 30), 
  ),      
             child: Text(
              'Order',
             style: TextStyle(
             color: Colors.black,
             fontSize: 11,
             fontWeight: FontWeight.bold,
    ),
  ),
),

          ],
        ),
      ),
    );
  }
}
