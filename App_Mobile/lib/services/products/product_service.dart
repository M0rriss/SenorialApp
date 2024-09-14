import 'package:dio/dio.dart';
import 'package:hive/hive.dart';
import 'package:senorial/core-url/urlconst.dart';
import 'package:senorial/models/Response/productos/product-response.dart';
import 'package:senorial/models/generic/generic-filter-request.dart';
import 'package:senorial/models/generic/generic-filter-response.dart';

class ProductService {
  Dio dio = Dio();

  Future<Response> listarProductos(ProductResponse req) async {
    var box = Hive.box("security");
    var token = box.get('token');
    dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "Bearer $token";
    String ruta = UrlProductos.idproduct.toString();
    final res = await dio.post(ruta, data: req);
    return res;
  }

  Future<GenericFilterResponse<ProductResponse>> filtrarProductos(
      GenericFilterRequest req) async {
    var box = Hive.box("security");
    var token = box.get('token');
    dio.options.headers['content-Type'] = 'application/json';
    dio.options.headers["authorization"] = "Bearer $token";
    String ruta = UrlProductos.filtro.toString();
    //Solo en casos especiales com tu comprenderas
    final res = await dio.post(ruta, data: {
      "numeroPagina": 1,
      "cantidad": 100,
      "filtros": req.filtros
        
      
      //  "filtros": [
      //   {"name": "Categoria", "value": "1"}
      // ]
    });
    GenericFilterResponse<ProductResponse> response =
        GenericFilterResponse(totalRegistros: 0, lista: []);
    for (var i in res.data['lista']) {
      ProductResponse tmp = ProductResponse.fromJson(i);
      response.lista.add(tmp);
    }
    response.totalRegistros = res.data['totalRegistros'];

    return response;
  }
}
