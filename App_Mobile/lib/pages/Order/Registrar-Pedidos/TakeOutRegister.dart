import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:m_senorial/components/Buttons/buttonIntems.dart';
import 'package:m_senorial/components/Buttons/buttonTwo.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';

class TakeOutRegister extends StatelessWidget {
  TakeOutRegister({Key? key}) : super(key: key);

  final codeController = TextEditingController();

  void navRegister(BuildContext context) {
  context.go('/home/takeoutregister/registerdata');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 20),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(height: 45),
              Row(
                children: [
                  ButtonBack(
                    onTap: () {
                      Navigator.of(context).pop();
                    },
                  ),
                  const SizedBox(width: 20),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: const [
                      Text(
                        'VENTAS',
                        style: TextStyle(
                          fontSize: 14.57,
                          fontWeight: FontWeight.bold,
                          color: Color.fromRGBO(252, 110, 42, 1),
                        ),
                      ),
                      Text(
                        'Mauricio',
                        style: TextStyle(
                          fontSize: 14,
                          fontWeight: FontWeight.bold,
                          color: Color.fromRGBO(153, 153, 153, 1),
                        ),
                      ),
                    ],
                  ),
                  Spacer(),
                  MyButtonTwo(
                    onTap: () => navRegister(context),
                    text: 'Registrar Pedido',
                    color: const Color.fromRGBO(255, 145, 15, 1),
                    buttonWidth: 143,
                    buttonHeight: 40,
                    fontSize: 17.5,
                  ),
                  const SizedBox(width: 20),
                  UserButton(
                    onTap: () {
                      // Acción al presionar el botón de usuario
                    },
                  ),
                ],
              ),
              const SizedBox(height: 100),
              const Buttonintems(
                name: 'Edson',
                price: 'S/. 30.00',
                items: '4 items',
                svgIconPath: 'lib/imagenes/IconCube.svg',
              ),
            ],
          ),
        ),
      ),
    );
  }
}
