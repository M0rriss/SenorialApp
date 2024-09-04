import 'package:m_senorial/models/Resquest/Pedido/listar_request.dart';
import 'package:m_senorial/models/Resquest/Pedido/orden_request.dart';

class PedidoRequest {
  OrdenRequest orden = OrdenRequest();
  List<ListarRequest> lista = [];
  Filtros filtro = Filtros();
  }


class Filtros {
  String idCategoria;
  String idSubCategoria;

  Filtros({this.idCategoria = "",this.idSubCategoria=""});
}