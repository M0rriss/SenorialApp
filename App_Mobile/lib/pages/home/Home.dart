  import 'package:flutter/material.dart';
  import 'package:m_senorial/components/square_icon.dart';

  class Home extends StatelessWidget{
    const Home ({super.key});
    
    @override
    Widget build (BuildContext context){
      return Scaffold(
        appBar: AppBar(),
        body:const Column(
          
          children:[ 
            SizedBox(height: 131,),
            Center(
              child: SquareIcon(imagePath: 'lib/images/google.png'),
            ), 
            const SizedBox(height: 6,),
            Text(
              "demo"
            ),
            const SizedBox(height: 109,),
            Center(
              child: SquareIcon(imagePath: 'lib/images/google.png'),
            ),
            const SizedBox(height: 6,),
            Text("Demo"),
          ],
        ),
      );
    }
  }