import 'package:flutter/material.dart';
import 'package:m_senorial/components/square_icon.dart';

class Home extends StatelessWidget {
  const Home({Key? key});

  Widget _buildContainer({
    required double left,
    required double top,
    required String text,
    required String imagePath,
  }) {
    return Container(
      width: 195,
      height: 220, // Ajusta según sea necesario para el tamaño deseado
      child: Column(
        children: [
          GestureDetector(
            onTap: () {
              print('$text tapped');
              // Navegar o realizar otra acción
            },
            child: Container(
              width: 195,
              height: 177,
              decoration: BoxDecoration(
                color: const Color(0xfffeecc8),
                borderRadius: BorderRadius.circular(20),
              ),
              child: Center(
                child: SquareIcon(
                  imagePath: imagePath,
                ),
              ),
            ),
          ),
          SizedBox(height: 16),
          Text(
            text,
            textAlign: TextAlign.center,
            style: const TextStyle(
              decoration: TextDecoration.none,
              fontSize: 16,
              color: Color(0xff646982),
              fontFamily: 'Sen-Regular',
              fontWeight: FontWeight.normal,
            ),
            maxLines: 2,
            overflow: TextOverflow.ellipsis,
          ),
        ],
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Center(
        child: Container(
          width: 430,
          height: 932,
          decoration: BoxDecoration(
            color: const Color(0xffffffff),
            borderRadius: BorderRadius.circular(25),
          ),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              _buildContainer(
                left: 117,
                top: 157,
                text: 'Comer Aqui',
                imagePath: 'lib/imagenes/Aqui.png',
              ),
              SizedBox(height: 40),
              _buildContainer(
                left: 118,
                top: 473,
                text: 'Para llevar',
                imagePath: 'lib/imagenes/Llevar.png',
              ),
            ],
          ),
        ),
      ),
    );
  }
}
  //   @override
  //   Widget build (BuildContext context){
  //     return Scaffold(
  //       appBar: AppBar(),
  //       body:const Column(
          
  //         children:[ 
  //           SizedBox(height: 131,),
  //           Center(
  //             child: SquareIcon(imagePath: 'lib/imagenes/ParaComerAqui.svg'),
  //           ), 
  //           const SizedBox(height: 6,),
  //           Text(
  //             "demo"
  //           ),
  //           const SizedBox(height: 109,),
  //           Center(
  //             child: SquareIcon(imagePath: 'lib/images/ParaLlevar.svg'),
  //           ),
  //           const SizedBox(height: 6,),
  //           Text("Demo"),
  //         ],
  //       ),
  //     );
  //   }
  // }