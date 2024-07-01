import 'package:dio/dio.dart';
import 'package:m_senorial/modules/shared/interface/crud_interface.dart';

class CrudService <T> implements CrudInterface{
  Dio dio = Dio();
  String ruta;
  CrudService({
    required this.ruta
  });
  @override
  Future<Response> get() async {
    return await dio.get(ruta); 
  }
}