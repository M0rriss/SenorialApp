import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

class ProductWidget extends StatefulWidget {
  final String productName; 
  final double productPrice; 
  final bool showControls;
  final VoidCallback? onDelete;
  final VoidCallback? precioInc;
  final VoidCallback? precioDec;
  final int incremento;
  final String ruta;

  ProductWidget({
    Key? key,
    required this.productName,
    required this.productPrice,
    required this.ruta,
    this.showControls = true,
    this.onDelete,
    this.precioInc,
    this.precioDec,
    this.incremento = 1,
  }) : super(key: key);

  @override
  _ProductWidgetState createState() => _ProductWidgetState();
}

class _ProductWidgetState extends State<ProductWidget> {
 int cantidad = 1;
 double precioVenta = 0;  


  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    precioVenta = widget.productPrice;
    
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
              child: Image.network(
                widget.ruta,
                width: 75,
                height: 60,
                fit: BoxFit.contain,
              ),
            ),
          ),
          const SizedBox(width: 10),
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                const SizedBox(height: 5),
                Text(
                  widget.productName,
                  style: const TextStyle(
                    fontSize: 16,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                const SizedBox(height: 10),
                Text(
                  'S/. ${widget.productPrice .toStringAsFixed(2)}',
                  // precioVenta.toString(),
                  style: const TextStyle(
                    fontSize: 15,
                    color: Colors.black,
                    fontWeight: FontWeight.w600,
                  ),
                ),
                // const SizedBox(height: 20),
                // const Row(
                //   children: [
                //     FaIcon(
                //       FontAwesomeIcons.pen,
                //       size: 12.5,
                //       color: Color.fromRGBO(116, 119, 123, 1),
                //     ),
                //     SizedBox(width: 4),
                //     Text(
                //       'Comentarios',
                //       style: TextStyle(
                //         fontSize: 10,
                //         color: Colors.grey,
                //       ),
                //     ),
                //   ],
                // ),
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
                            onTap: widget.precioDec,
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
                              widget.incremento.toString(),
                              style: const TextStyle(
                                fontSize: 12.12,
                                color: Colors.white,
                                fontWeight: FontWeight.bold,
                              ),
                            ),
                          ),
                          GestureDetector(
                            onTap: widget.precioInc,
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
                    right: -12,
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

