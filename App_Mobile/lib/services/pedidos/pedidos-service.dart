import 'package:dio/dio.dart';
import 'package:hive/hive.dart';
import 'package:senorial/core-url/urlconst.dart';
import 'package:senorial/models/Resquest/Pedido/pedidos-request.dart';

class PedidosService{
  final Dio dio = Dio();

Future<Response> RegistrarPedido (PedidosRequest pedido) async{
      var box = Hive.box("security");
     var token = box.get('token');
    dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "Bearer $token";

    String ruta = UrlPedidos.pedido;
    final response = await dio.post(ruta, data: pedido.toJson());
    return response;



  }
  Future<Response> ActualizarPedido (int id, PedidosRequest pedido) async{
      var box = Hive.box("security");
     var token = box.get('token');
    dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "Bearer $token";

    String url = UrlPedidos.pedido;
    final response = await dio.put(url, data: pedido.toJson());
    return response;

  }
 Future<bool> CancelarPedido(int idPedido) async {
    var box = Hive.box("security");
    var token = box.get('token');
    dio.options.headers['Content-Type'] = 'application/json';
    dio.options.headers["Authorization"] = "Bearer $token";

    String url = '${UrlPedidos.cancelar}?idPedido=$idPedido'; // Asegúrate de que la URL es correcta
    final response = await dio.delete(url);
    return true;
  }
}