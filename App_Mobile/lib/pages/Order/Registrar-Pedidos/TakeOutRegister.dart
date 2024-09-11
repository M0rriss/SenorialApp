import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:hive/hive.dart';
import 'package:m_senorial/components/Buttons/buttonIntems.dart';
import 'package:m_senorial/components/Buttons/buttonTwo.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';

class TakeOutRegister extends StatefulWidget {
  const TakeOutRegister({Key? key}) : super(key: key);

  @override
  _TakeOutRegisterState createState() => _TakeOutRegisterState();
}

class _TakeOutRegisterState extends State<TakeOutRegister> {
  final codeController = TextEditingController();

  void navRegister(BuildContext context) {
    context.go('/home/takeoutregister/registerdata');
  }

  String nombreUsuario = '';


  @override
  void initState() {
    super.initState();

    mostrarNombre().then((value) => {
          setState(() {
            String unico = value.substring(0, value.indexOf(" "));
            nombreUsuario = unico;
          })
        });
  }
  

  Future<String> mostrarNombre() async {
    var box = await Hive.openBox('security'); // Asegurarse de que la caja está abierta
    var nombre = box.get('nombre');
    return nombre;
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
                    children: [
                      const Text(
                        'VENTAS',
                        style: TextStyle(
                          fontSize: 14.57,
                          fontWeight: FontWeight.bold,
                          color: Color.fromRGBO(252, 110, 42, 1),
                        ),
                      ),
                      Text(
                        nombreUsuario,  
                        style: const TextStyle(
                          fontSize: 14,
                          fontWeight: FontWeight.bold,
                          color: Color.fromRGBO(153, 153, 153, 1),
                        ),
                      ),
                    ],
                  ),
                  const Spacer(),
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
