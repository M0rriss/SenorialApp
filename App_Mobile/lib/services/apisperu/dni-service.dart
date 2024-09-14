import 'package:dio/dio.dart';
import 'package:hive/hive.dart';
import 'package:senorial/core-url/urlconst.dart';
import 'package:senorial/models/Response/servicio/dni-response.dart';

class DniService {
  final Dio dio= Dio();
  
  Future<DniResponse> buscarDni(String doc) async
  {
     var box = Hive.box("security");
     var token = box.get('token');
     dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "Bearer $token";
    String ruta = UrlServicios.dni;
    final res = await dio.get('$ruta?dni=$doc');
    DniResponse dni = DniResponse.fromJson(res.data);
    return dni;
  }
}