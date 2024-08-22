import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

class Loading extends StatefulWidget {
  final String destination;

  Loading({required this.destination});

  @override
  _LoadingState createState() => _LoadingState();
}

class _LoadingState extends State<Loading> with SingleTickerProviderStateMixin {
  late AnimationController _controller;

  @override
  void initState() {
    super.initState();
    _controller = AnimationController(
      duration: const Duration(seconds: 3),
      vsync: this,
    )..repeat();

    // Redirigir a la pantalla de destino después de 2 segundos
    Future.delayed(Duration(seconds: 2), () {
      context.go(widget.destination); // Navega a la ruta de destino
    });
  }

  @override
  void dispose() {
    _controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 250, 250, 250),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const SizedBox(height: 190),
            Container(
              width: 384.81,
              height: 218.14,
              alignment: Alignment.center,
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
            const SizedBox(height: 70),
            SizedBox(
              width: 79,
              height: 79,
              child: AnimatedBuilder(
                animation: _controller,
                builder: (context, child) {
                  return Transform.rotate(
                    angle: _controller.value * 2.0 * 3.14,
                    child: CustomPaint(
                      painter: GradientCircularProgressIndicatorPainter(
                        0.65,
                      ),
                      child: const Center(
                        child: SizedBox(
                          width: 50,
                          height: 50,
                          child: CircularProgressIndicator(
                            strokeWidth: 8.0,
                            valueColor: AlwaysStoppedAnimation<Color>(Colors.transparent),
                          ),
                        ),
                      ),
                    ),
                  );
                },
              ),
            ),
            const SizedBox(height: 20),
          ],
        ),
      ),
    );
  }
}

class GradientCircularProgressIndicatorPainter extends CustomPainter {
  final double progress;

  GradientCircularProgressIndicatorPainter(this.progress);

  @override
  void paint(Canvas canvas, Size size) {
    final Paint paint = Paint()
      ..shader = LinearGradient(
        colors: [
          Color.fromRGBO(100, 105, 130, 1),
          Color.fromRGBO(137, 138, 141, 1),
          Color.fromRGBO(225, 225, 225, 1),
        ],
      ).createShader(Rect.fromLTWH(0, 0, size.width, size.height))
      ..style = PaintingStyle.stroke
      ..strokeWidth = 8.0
      ..strokeCap = StrokeCap.round;

    final Rect rect = Offset.zero & size;
    final double startAngle = 3.14 / 15; // Empieza en la parte superior
    final double sweepAngle = progress * 2 * 3.14; // Controla cuánto del círculo se dibuja

    canvas.drawArc(rect, startAngle, sweepAngle, false, paint);
  }

  @override
  bool shouldRepaint(CustomPainter oldDelegate) => false;
}
