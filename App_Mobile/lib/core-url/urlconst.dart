const String dominio = "https://localhost:7283";
 //const String dominio = "https://senorialapp.somee.com";

class SubRutas {
  //AUTH
  static const String auth = "$dominio/api/Auth";
  static const String tables = "$dominio/api/Mesa";
  static const String categoria = "$dominio/api/Categoria"; 
  static const String producto = "$dominio/api/Producto";
  static const String home = "$dominio/api/TipoPedido";

  static const String orden = "$dominio/api/Pedido";
  static const String pedidosLlevar= "$dominio/api/PedidoLlevar";
  static const String detalleLlevar = "$dominio/api/DetallePedidoLlevar";
  static const String servicios = "$dominio/api/Servicios";
}

class UrlAuth {
  static const String login = "${SubRutas.auth}/Login/Mobile";
  static const String forget = "${SubRutas.auth}/SendRecoveryCode/movil";
  static const String recovery = "${SubRutas.auth}/RecoveryPassword/movil";
}
  //MESAS 
class UrlMesas {
  static const String salestable = "${SubRutas.tables}/MesaLocal";
}
//CATEGORIAS
class UrlCategorias {
  static const String listcategoria = "${SubRutas.categoria}/Listado";
  static const String listar = "${SubRutas.categoria}/listar";
  static const String fitrocategoria = "${SubRutas.categoria}/listar/Sub";
  static const String listarsub = "${SubRutas.categoria}/SubCategoria";
}
//PRODUCTO
class UrlProductos {
  static const String listproduct = "${SubRutas.producto}/Listado";
  static const String idproduct = SubRutas.producto;
  static const String filtro= "${SubRutas.producto}/Filtro/Ecommerce";
}
//HOME
class   UrlHome {
static const String listipopedido = "${SubRutas.home}/Listado";
}

class UrlPedidos {
  static const String pedido = SubRutas.orden;
  static const String pedidosLocal = "${SubRutas.orden}/PedidosLocal";
  static const String detPedidos = "${SubRutas.orden}/DetPedidos";
}
class UrlPedidosLlevar { // Modificar
  static const String pedidollevar = "${SubRutas.pedidosLlevar}/Create";
}
class UrlServicios {
  static const String dni = "${SubRutas.servicios}/Dni";
}