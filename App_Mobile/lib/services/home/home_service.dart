import 'package:m_senorial/models/Resquest/home/home-request.dart';
import 'package:m_senorial/models/Response/home/home-response.dart';
import 'package:m_senorial/services/crud_service.dart';

class HomeService extends CrudService<HomeRequest,HomeResponse> {
  HomeService({required super.ruta,required super.dio}); 

}