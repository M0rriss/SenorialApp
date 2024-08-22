import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

class ProductWidget extends StatefulWidget {
  final bool showControls;
  final VoidCallback? onDelete; // Hacer que onDelete sea opcional

  ProductWidget({this.showControls = true, this.onDelete});

  @override
  _ProductWidgetState createState() => _ProductWidgetState();
}

class _ProductWidgetState extends State<ProductWidget> {
  int cantidad = 2;

  void incrementarCantidad() {
    setState(() {
      cantidad++;
    });
  }

  void decrementarCantidad() {
    if (cantidad > 0) {
      setState(() {
        cantidad--;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 8.0, horizontal: 16.0),
      child: Row(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const SizedBox(width: 15),
          Container(
            width: 96,
            height: 93,
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(12),
              color: const Color.fromRGBO(254, 242, 215, 1),
            ),
            child: Center(
              child: Image.asset(
                'lib/imagenes/burger1.png',
                width: 75,
                height: 60,
                fit: BoxFit.contain,
              ),
            ),
          ),
          const SizedBox(width: 10),
          const Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                SizedBox(height: 5),
                Text(
                  'Hamburguesa de Pollo',
                  style: TextStyle(
                    fontSize: 16,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                SizedBox(height: 10),
                Text(
                  'S/. 30.00',
                  style: TextStyle(
                    fontSize: 15,
                    color: Colors.black,
                    fontWeight: FontWeight.w600,
                  ),
                ),
                SizedBox(height: 20),
                Row(
                  children: [
                    FaIcon(
                      FontAwesomeIcons.pen,
                      size: 12.5,
                      color: Color.fromRGBO(116, 119, 123, 1),
                    ),
                    SizedBox(width: 4),
                    Text(
                      'Comentarios',
                      style: TextStyle(
                        fontSize: 10,
                        color: Colors.grey,
                      ),
                    ),
                  ],
                ),
              ],
            ),
          ),
          if (widget.showControls) ...[
            Stack(
              alignment: Alignment.centerRight,
              children: [
                Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    const SizedBox(height: 68),
                    Container(
                      width: 79.73,
                      height: 24.24,
                      decoration: BoxDecoration(
                        color: const Color.fromARGB(255, 7, 6, 6),
                        borderRadius: BorderRadius.circular(29.09),
                      ),
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          GestureDetector(
                            onTap: decrementarCantidad,
                            child: Container(
                              width: 19.39,
                              height: 19.39,
                              decoration: const BoxDecoration(
                                shape: BoxShape.circle,
                                color: Color.fromRGBO(255, 144, 0, 1),
                              ),
                              child: const Center(
                                child: FaIcon(
                                  FontAwesomeIcons.minus,
                                  size: 10,
                                  color: Colors.white,
                                ),
                              ),
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(horizontal: 14),
                            child: Text(
                              '$cantidad',
                              style: const TextStyle(
                                fontSize: 12.12,
                                color: Colors.white,
                                fontWeight: FontWeight.bold,
                              ),
                            ),
                          ),
                          GestureDetector(
                            onTap: incrementarCantidad,
                            child: Container(
                              width: 19.39,
                              height: 19.39,
                              decoration: const BoxDecoration(
                                shape: BoxShape.circle,
                                color: Color.fromRGBO(255, 144, 0, 1),
                              ),
                              child: const Center(
                                child: FaIcon(
                                  FontAwesomeIcons.plus,
                                  size: 12,
                                  color: Colors.white,
                                ),
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
                if (widget.showControls && widget.onDelete != null)
                  Positioned(
                    top: 20,
                    right: -16,
                    child: IconButton(
                      icon: const Icon(Icons.delete),
                      color: const Color.fromRGBO(255, 145, 15, 1),
                      onPressed: widget.onDelete,
                    ),
                  ),
              ],
            ),
          ],
          const SizedBox(width: 15),
        ],
      ),
    );
  }
}
