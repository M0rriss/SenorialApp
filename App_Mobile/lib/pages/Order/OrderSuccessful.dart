import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';  // Importa go_router para la navegación
import 'package:lottie/lottie.dart';  // Importa Lottie para la animación

class OrderSuccessful extends StatefulWidget {
  const OrderSuccessful({Key? key}) : super(key: key);

  @override
  _OrderSuccessfulState createState() => _OrderSuccessfulState();
}

class _OrderSuccessfulState extends State<OrderSuccessful> {
  @override
  void initState() {
    super.initState();
    // Esperar 3 segundos antes de redirigir
    Future.delayed(const Duration(seconds: 3), () {
      // Redirigir a la pantalla de mesas (home)
      context.go('/home');
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,  // Fondo blanco
      body: Center(  // Centrar el contenido en la pantalla
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,  // Centrar verticalmente
          children: [
            // Animación Lottie para mostrar el check
            Lottie.asset(
              'lib/imagenes/Check.json',  // Ruta del archivo JSON para la animación
              width: 350,  // Aumenta el tamaño de la animación
              height: 350,
              onLoaded: (composition) {
                // Opcional: manejar acciones cuando la animación se carga
              },
            ),
            const SizedBox(height: 30),  // Espaciado entre la animación y el texto
            // Texto 'Successful'
            Text(
              'Successful',
              style: TextStyle(
                fontSize: 29,
                fontWeight: FontWeight.bold,
                color: const Color.fromRGBO(255, 145, 15, 1),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
