  import 'package:dio/dio.dart';
  import 'package:hive/hive.dart';
import 'package:m_senorial/core-url/urlconst.dart';
import 'package:m_senorial/models/Response/productos/product-response.dart';


  class ProductService{
    Dio dio = Dio();

    Future<Response>listarProductos(ProductResponse req) async{
      var box = Hive.box("security");
      var token = box.get('token');
      dio.options.headers['content-Type'] = 'application/json';
      dio.options.headers["authorization"] = "Bearer $token";
      String ruta = UrlProductos.idproduct.toString();
      final res = await dio.post(ruta,data:req);
      return res;
    }

  }