class DetallePedidoMesaRequest {
  int idPedidoMesa;
  int idMesaDetalle;
  int idProducto;
  int idDetallePedido;
  String nombreProducto;
  int cantidadItems;
  double subtotal;
  double precio;
  String ruta;

  DetallePedidoMesaRequest({
    this.idPedidoMesa = 0,
    this.idProducto = 0,
    this.idDetallePedido = 0,
    this.idMesaDetalle = 0,
    this.nombreProducto = "",
    this.cantidadItems = 1,
    this.subtotal = 0.0,
    this.precio = 0,
    this.ruta = "",
  });

  // factory DetallePedidoMesaRequest.fromJson(Map<String, dynamic> json) {
  //    return DetallePedidoMesaRequest(
  //     idPedidoMesa: json['idPedidoMesa'],
  //     idMesaDetalle: json['idMesaDetalle'],
  //     nombreProducto: json['nombreProducto'],
  //     cantidadItems: json['cantidadItems'],
  //     subtotal: (json['subtotal']).toDouble(),
  //     precio: (json['precioProducto']).toDouble(),
  //     ruta: json['urlImagen'],
  //   );
  // }
  factory DetallePedidoMesaRequest.fromJson(Map<String, dynamic> json) {
    return DetallePedidoMesaRequest(
      idPedidoMesa: json['idPedido'] ?? 0,
      idMesaDetalle: 0,
      idDetallePedido: json['idDetallePedido'] ?? 0,
      idProducto: json['idProducto'] ?? 0,
      nombreProducto: json['nombreProducto'] ?? '',
      cantidadItems: json['cantidad'] ?? 0,
      subtotal: (json['precioProducto'] ?? 0).toDouble(),
      precio: (json['precioProducto'] ?? 0).toDouble(),
      ruta: json['urlImagen'] ?? '',
    );
  }
}
