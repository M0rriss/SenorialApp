class ListarRequest {
  int idProducto;
  int cantidad;
  double precio;
  String nombre;
  int idDetallePedido;
  String ruta;

  ListarRequest(
      {this.idDetallePedido = 0,
      this.idProducto = 0,
      this.cantidad = 0,
      this.precio = 0,
      this.nombre = "",
      this.ruta = ""});
}
