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

class PedidoLlevarRequest extends PedidoRequest {
 List<ProductoLlevarRequest> productosLlevar = []; 
}
// Definición de un producto específico para "para llevar"
class ProductoLlevarRequest {
  int idPedidoLlevar;   // ID del pedido para llevar
  int idProducto;       // ID del producto
  int cantidad;         // Cantidad de productos en el pedido
  double precioUnitario; // Precio unitario del producto

  ProductoLlevarRequest({
    this.idPedidoLlevar = 0, 
    this.idProducto = 0, 
    this.cantidad = 0, 
    this.precioUnitario = 0,
  });
}