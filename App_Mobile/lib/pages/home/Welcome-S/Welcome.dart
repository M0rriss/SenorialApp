import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

class Welcome extends StatefulWidget {
  @override
  _WelcomeState createState() => _WelcomeState();
}

class _WelcomeState extends State<Welcome> {
  bool _isImageClicked = false;

  void _onImageClick() {
    setState(() {
      _isImageClicked = true;
    });
    // Navegar a la pantalla de Loading y luego a Login
    context.go('/loading', extra: '/login');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 250, 250, 250),
      body: Center(
        child: _isImageClicked
            ? SizedBox() // O podrías tener un indicador de carga aquí si quieres
            : GestureDetector(
                onTap: _onImageClick,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    SizedBox(height: 40), // Separación arriba de la imagen
                    Container(
                      width: 384.81,
                      height: 218.14,
                      child: Padding(
                        padding: const EdgeInsets.only(top: 75.0),
                        child: Transform.scale(
                          scale: 2.8,
                          child: Image.asset(
                            'lib/imagenes/SenorialLogoBW.png',
                            fit: BoxFit.contain,
                          ),
                        ),
                      ),
                    ),
                  ],
                ),
              ),
      ),
    );
  }
}
