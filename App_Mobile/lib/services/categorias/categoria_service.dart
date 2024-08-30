import 'package:dio/dio.dart';
import 'package:hive_flutter/hive_flutter.dart';
import 'package:m_senorial/core-url/urlconst.dart';

class CategoriaService {
  final Dio dio = Dio();

  CategoriaService() {
    // Configuración inicial de Dio, si es necesario
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

    // Si la respuesta es null o vacía, lanzamos una excepción personalizada
    if (res.data == null || (res.data is List && res.data.isEmpty)) {
      throw Exception('No se encontró ningún registro o la respuesta es vacía');
    }

    return res;
  }
}
