import 'package:dio/dio.dart';
import 'package:hive/hive.dart';
import 'package:senorial/core-url/urlconst.dart';

class MesasService  {
  final Dio _dio;
  

  MesasService() : _dio = Dio() {
    // Configuración inicial de Dio si es necesario
    _dio.options.headers['content-Type'] = 'application/json';
  }

  Future<List> listarMesas() async {
    var box = await Hive.openBox('security');  // Asegurarse de que la caja está abierta
    var token = box.get('token');
    _dio.options.headers["authorization"] = "Bearer $token";

    // Asegúrate de que UrlMesa está definido y contiene 'list'
    String ruta = UrlMesas.salestable;
    
    final response = await _dio.get(ruta);
    final list = response.data as List;

    return list;
  }
   Future<List> listarDetallesProductosMesa(int idMesa, int idPedido,) async {
    var box = await Hive.openBox('security');  // Asegurarse de que la caja está abierta
    var token = box.get('token');
    _dio.options.headers["authorization"] = "Bearer $token";

    // Asegúrate de que UrlMesa está definido y contiene 'list'
    String ruta = "${UrlPedidos.detPedidos}?IdMesa=$idMesa&IdPedido=$idPedido";
    
    final response = await _dio.get(ruta);
    final list = response.data as List;

     return list;
    
  }
}
