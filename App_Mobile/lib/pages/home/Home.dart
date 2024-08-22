import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:m_senorial/components/Extras/square_icon.dart';

enum ActionType { comerAqui, paraLlevar }

class Home extends StatelessWidget {
  const Home({Key? key}) : super(key: key);

  void _handleOnTap(BuildContext context, ActionType actionType) {
  switch (actionType) {
    case ActionType.comerAqui:
      context.go('/home/salestable');
      break;
    case ActionType.paraLlevar:
      context.go('/home/takeoutregister'); // Asegúrate de usar el path correcto
      break;
  }
}


  Widget _buildContainer({
    required BuildContext context,
    required double left,
    required double top,
    required String text,
    required String imagePath,
    required ActionType actionType,
  }) {
    return Container(
      width: 195,
      height: 220,
      child: Column(
        children: [
          GestureDetector(
            onTap: () => _handleOnTap(context, actionType),
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
                context: context,
                left: 117,
                top: 157,
                text: 'Comer Aqui',
                imagePath: 'lib/imagenes/Aqui.png',
                actionType: ActionType.comerAqui,
              ),
              SizedBox(height: 40),
              _buildContainer(
                context: context,
                left: 118,
                top: 473,
                text: 'Para llevar',
                imagePath: 'lib/imagenes/Llevar.png',
                actionType: ActionType.paraLlevar,
              ),
            ],
          ),
        ),
      ),
    );
  }
}
