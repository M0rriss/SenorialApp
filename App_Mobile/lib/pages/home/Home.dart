import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:m_senorial/components/Extras/square_icon.dart';
import 'package:m_senorial/core-url/urlconst.dart';
import 'package:m_senorial/models/Response/home/home-response.dart';
import 'package:m_senorial/models/Resquest/Pedido/pedido_request.dart';

class Home extends StatelessWidget {
  const Home({Key? key}) : super(key: key);

  void _handleOnTap(BuildContext context, HomeResponse pedido) {
    switch (pedido.idTipoPedido) {
      case 1: // ID para "Comer Aquí"
        context.go('/home/salestable');
        break;
      case 2: // ID para "Para Llevar"
        PedidoRequest roq = PedidoRequest();
        roq.orden.idMesa = 0;
        roq.orden.idTipoPedido = 1;
        context.go('/home/takeoutregister', extra: roq);
        break;
      default:
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
              content: Text('Acción no disponible para este tipo de pedido.')),
        );
        break;
    }
  }

  Future<List<HomeResponse>> tipoPedido() async {
    final Dio dio = Dio();
    final response = await dio.get(UrlHome.listipopedido);

    // Convertir la respuesta a una lista de objetos HomeResponse
    List<dynamic> data = response.data;
    List<HomeResponse> list =
        data.map((item) => HomeResponse.fromJson(item)).toList();

    return list;
  }

  Widget _buildContainer({
    required BuildContext context,
    required double left,
    required double top,
    required String text,
    required String imagePath,
    required Function()? onTap,
  }) {
    return Container(
      width: 195,
      height: 220,
      child: Column(
        children: [
          GestureDetector(
            onTap: onTap,
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
      body: FutureBuilder<List<HomeResponse>>(
        future: tipoPedido(),
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(child: CircularProgressIndicator());
          } else if (snapshot.hasError) {
            return Center(child: Text('Error: ${snapshot.error}'));
          } else if (!snapshot.hasData || snapshot.data!.isEmpty) {
            return Center(child: Text('No hay datos disponibles'));
          } else {
            List<HomeResponse> pedidos = snapshot.data!;

            // Filtrar los pedidos por tipo
            List<HomeResponse> comerAqui =
                pedidos.where((pedido) => pedido.idTipoPedido == 1).toList();
            List<HomeResponse> paraLlevar =
                pedidos.where((pedido) => pedido.idTipoPedido == 2).toList();

            return Center(
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
                    // Mostrar "Comer Aquí"
                    ...comerAqui.map((pedido) {
                      return _buildContainer(
                        context: context,
                        left: 0,
                        top: 0,
                        text: pedido.descripcionSpa,
                        imagePath: 'lib/imagenes/Aqui.png',
                        onTap: () => _handleOnTap(context, pedido),
                      );
                    }).toList(),
                    SizedBox(height: 50), // Espacio entre las secciones
                    // Mostrar "Para Llevar"
                    ...paraLlevar.map((pedido) {
                      return _buildContainer(
                        context: context,
                        left: 0,
                        top: 0,
                        text: pedido.descripcionSpa,
                        imagePath: 'lib/imagenes/Llevar.png',
                        onTap: () => _handleOnTap(context, pedido),
                      );
                    }).toList(),
                  ],
                ),
              ),
            );
          }
        },
      ),
    );
  }
}
