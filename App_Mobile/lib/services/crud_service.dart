import 'package:dio/dio.dart';

class CrudService<T, Y> {
  Dio dio;
  String ruta;
  CrudService({required this.ruta, required this.dio});
  Future<List> getAll() async {
    dio.options.headers["authorization"] = "token";
    var res = await dio.get(ruta);
    List data = res.data as List;
    return data;
  }

  Future<Response> get() async {
    dio.options.headers["authorization"] = "token";
    var res = await dio.get(ruta);
    return res.data;
  }

  Future<Response> post(Y obj) async {
    dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "token";
    return await dio.post(ruta, data: obj);
  }

  Future<Response> put(T obj) async {
    dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "token";
    return await dio.put(ruta, data: obj);
  }
}