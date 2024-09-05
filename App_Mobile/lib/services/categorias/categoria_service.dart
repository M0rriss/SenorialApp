import 'package:dio/dio.dart';
import 'package:hive_flutter/hive_flutter.dart';
import 'package:m_senorial/core-url/urlconst.dart';

class CategoriaService {
  final Dio dio = Dio();

  CategoriaService() {
    
    dio.options.headers['content-Type'] = 'application/json';
  }

  Future<Response> listarCategoria() async {
    var box = Hive.box("security");
    var token = box.get('token');

    if (token == null) {
      throw Exception('Token no encontrado en el almacenamiento local');
    }

    dio.options.headers["authorization"] = "Bearer $token";
    String ruta = UrlCategorias.listcategoria;

    final res = await dio.get(ruta);

    
    if (res.data == null || (res.data is List && res.data.isEmpty)) {
      throw Exception('No se encontró ningún registro o la respuesta es vacía');
    }

    return res;
  }

  Future<Response> listarsubCategorias() async {
    var box = Hive.box("security");
    var token = box.get('token');
    dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "Bearer $token";
    String ruta = UrlCategorias.listarsub.toString();
    final res = await dio.get(ruta);
    return res;
  } 


   
 
  Future<Response> filtroSubCategoria(int idCategoria) async {
     var box = Hive.box("security");
    var token = box.get('token');
    dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "Bearer $token";
    String ruta = UrlCategorias.fitrocategoria.toString();
    final res = await dio.get('$ruta?idCategoria=$idCategoria');
    return res;
  }
}
