import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:m_senorial/components/Buttons/buttonExtras.dart';
import 'package:m_senorial/components/Buttons/buttonUser.dart';
import 'package:m_senorial/components/Buttons/buttonback.dart';
import 'package:m_senorial/components/Buttons/buttonOrden.dart';
import 'package:m_senorial/components/Extras/productwidget.dart';
import 'package:m_senorial/models/Resquest/Pedido/detalle_pedido_mesa_request.dart';
import 'package:m_senorial/models/Resquest/Pedido/pedido_request.dart';
import 'package:m_senorial/services/mesas/mesa_service.dart';

class OrderMenu extends StatefulWidget {
  final PedidoRequest pedido;

  const OrderMenu({Key? key, required this.pedido}) : super(key: key);

  @override
  _OrderMenuState createState() => _OrderMenuState();
}

class _OrderMenuState extends State<OrderMenu> {
  final codeController = TextEditingController();
  List<DetallePedidoMesaRequest> productos = [];
final MesasService mesassService = MesasService();
  @override
  void initState() {
    super.initState();
    
    listarDetalleProductosMesa(
      widget.pedido.orden.idMesa, 
      widget.pedido.orden.idPedido);
       productos = convertir(widget.pedido);
       
  }

List<DetallePedidoMesaRequest> convertir(PedidoRequest pedidoRequest) {
  List<DetallePedidoMesaRequest> productosConvertidos = [];

  for (var producto in pedidoRequest.lista) {
    productosConvertidos.add(DetallePedidoMesaRequest(
      idPedidoMesa: pedidoRequest.orden.idPedido,  
      idMesaDetalle: pedidoRequest.orden.idMesa,   
      nombreProducto: producto.nombre,             
      cantidadItems: producto.cantidad,            
      subtotal: producto.precio * producto.cantidad, 
      precio: producto.precio,                     
      ruta: producto.ruta,                         
    ));
  }

  return productosConvertidos;
}




 Future<void> listarDetalleProductosMesa(int idMesa, int idPedido) async {
  final response = await mesassService.listarDetallesProductosMesa(idMesa, idPedido);
  
  // Imprime los datos que llegan de la API para depurar
  print('Datos recibidos: $response');
  
  setState(() {
    productos = response.map((data) => DetallePedidoMesaRequest.fromJson(data)).toList();
  });
}

  
  double calcularSubtotal() {
    return productos.fold(0.0, (total, producto) => total + producto.subtotal);
  }

 

   @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const SizedBox(height: 45),
            Row(
              children: [
                const SizedBox(width: 20),
               ButtonBack(onTap: () => context.go('/home/salestable')),
                const SizedBox(width: 20),
                const Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'ORDER',
                      style: TextStyle(
                        fontSize: 14.57,
                        fontWeight: FontWeight.bold,
                        color: Color.fromRGBO(252, 110, 42, 1),
                      ),
                    ),
                  ],
                ),
                const SizedBox(width: 233),
                UserButton(
                  onTap: () {
                    
                  },
                ),
              ],
            ),
            const SizedBox(height: 30),
            Row(
              children: [
                const Spacer(),
                MyButtonExtras(
                  borderRadius: 10,
                  onTap: () {},
                  text: 'MESA - ${widget.pedido.orden.idMesa}',
                ),
                const SizedBox(width: 20),
              ],
            ),
            const SizedBox(height: 10),
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 29.0),
              child: Text(
                'Total  Items',
                style: TextStyle(
                  color: Color.fromRGBO(156, 155, 166, 1),
                  fontSize: 15.7,
                  fontWeight: FontWeight.normal,
                ),
              ),
            ),
            const SizedBox(height: 14),
            
            ...productos.map((producto) {
              return Padding(
                padding: const EdgeInsets.only(bottom: 14.0),
                child: ProductWidget(
                  ruta: producto.ruta,
                  productName: producto.nombreProducto,
                  productPrice: producto.subtotal,
                  showControls: false,
                ),
              );
            }).toList(),
            
            Center(
              child: ClipRRect(
                borderRadius:
                    BorderRadius.circular(100), 
                child: Container(
                  width: 365,
                  height: 5,
                  color: const Color.fromRGBO(118, 118, 118, 1),
                  margin: const EdgeInsets.symmetric(vertical: 10),
                ),
              ),
            ),
            
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                const Padding(
                  padding: EdgeInsets.symmetric(horizontal: 35.0),
                  child: Text(
                    'Order Subtotal',
                    style: TextStyle(
                      fontSize: 25,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 30.0),
                  child: Text(
                    'S/. ${calcularSubtotal().toStringAsFixed(2)}',
                    style: const TextStyle(
                      fontSize: 25,
                      fontWeight: FontWeight.normal,
                    ),
                  ),
                ),
              ],
            ),
            const SizedBox(height: 40),
            Center(
              child: MyButtonOrdern(
                onTap: () {
                  
                },
                text: 'Reapertura de Mesa',
                borderRadius: 0,
                color: const Color.fromRGBO(255, 145, 15, 1),
              ),
            ),
            const SizedBox(height: 15),
            Center(
              child: MyButtonOrdern(
                onTap: () {
                  
                },
                text: 'Generar Comprovante',
                borderRadius: 0,
                color: const Color.fromRGBO(236, 40, 40, 1),
              ),
            ),
            const SizedBox(height: 20),
          ],
        ),
      ),
    );
  }
}