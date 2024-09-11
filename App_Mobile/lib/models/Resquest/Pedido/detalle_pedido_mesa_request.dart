class DetallePedidoMesaRequest {
  int IdPedidoMesa;
  int IdMesaDetalle;
  String NombreProducto;
  int CantidadItems;
  double Subtotal;
  double Precio;
  String Ruta;

  DetallePedidoMesaRequest({
    this.IdPedidoMesa = 0,
    this.IdMesaDetalle = 0,
    this.NombreProducto = "",
    this.CantidadItems = 0,
    this.Subtotal = 0.0,
    this.Precio = 0,
    this.Ruta = "",


  });

  // Método factory para crear una instancia desde un JSON
  factory DetallePedidoMesaRequest.fromJson(Map<String, dynamic> json) {
    return DetallePedidoMesaRequest(
      IdPedidoMesa: json['IdPedidoMesa'] ?? 0,
      IdMesaDetalle: json['IdMesaDetalle'] ?? 0,
      NombreProducto: json['NombreProducto'] ?? "",
      CantidadItems: json['CantidadItems'] ?? 0,
      Subtotal: (json['Subtotal'] ?? 0.0).toDouble(),
    );
  }
}
