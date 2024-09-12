
import 'package:dio/dio.dart';
import 'package:hive/hive.dart';
import 'package:m_senorial/core-url/urlconst.dart';
import 'package:m_senorial/models/Resquest/Pedido/pedidosllevar-request.dart';

class PedidosLlevarService{

  final Dio dio = Dio();
  Future<Response> RegistrarPedido ( OrdenLlevarRequest pedido) async{
      var box = Hive.box("security");
     var token = box.get('token');
    dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "Bearer $token";

    String ruta = UrlPedidosLlevar.pedidollevar;
    final response = await dio.post(ruta, data: pedido.toJson());
    return response;

  }
  Future<Response> ListarPedidoLlevar ( OrdenLlevarRequest pedido ) async{
     var box = Hive.box("security");
     var token = box.get('token');
    dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "Bearer $token";
    String ruta = UrlPedidosLlevar.listarpedidollevar;
    final response = await dio.get(ruta, data: pedido.toJson());
    return response;
  }
  Future<Response> DetallePedidoLlevar ( int idPedidoLlevar ) async{
     var box = Hive.box("security");
     var token = box.get('token');
    dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "Bearer $token";
    String ruta = "${UrlPedidosLlevar.listarpedidollevar}?idPedidoLlevar=$idPedidoLlevar";
    final response = await dio.get(ruta);
    return response;
  }
}