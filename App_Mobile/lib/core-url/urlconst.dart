const String dominio = "https://localhost:7283";
// const String dominio = "https://senorialapp.somee.com/";

class SubRutas {
  //AUTH
  static const String auth = "$dominio/api/Auth";
  static const String tables = "$dominio/api/Mesa";
  static const String categoria = "$dominio/api/Categoria"; 
  static const String producto = "$dominio/api/Producto";
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
}
//PRODUCTO
class UrlProductos {
  static const String listproduct = "${SubRutas.producto}/Listado";
  static const String idproduct = "${SubRutas.producto}"; 
}