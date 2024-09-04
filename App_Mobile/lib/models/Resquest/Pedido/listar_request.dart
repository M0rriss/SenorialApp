class ListarRequest {
  int idProducto;
  int cantidad;
  double precio;
  String nombre;
  String ruta;

  ListarRequest({this.idProducto = 0,this.cantidad = 0,this.precio = 0,this.nombre = "",this.ruta = ""});
}