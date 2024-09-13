import 'dart:convert';

OrdenLlevarRequest ordenLlevarRequestFromJson(String str) =>
    OrdenLlevarRequest.fromJson(json.decode(str));

String ordenLlevarRequestToJson(OrdenLlevarRequest data) =>
    json.encode(data.toJson());

class OrdenLlevarRequest {
  int idPedidoLlevar;
  int idEmpleado;
  int idCliente;
  String nombreCliente;
  DateTime fechaPedido;
  int estado;
  double total;
  int idTipoPedido;
  int cantidad;
  List<DetallesLlevar> detallesLlevar;

  OrdenLlevarRequest({
    required this.idPedidoLlevar,
    required this.idEmpleado,
    required this.idCliente,
    required this.nombreCliente,
    required this.fechaPedido,
    required this.estado,
    required this.total,
    required this.idTipoPedido,
    required this.detallesLlevar,
    this.cantidad = 1,
  });

  factory OrdenLlevarRequest.fromJson(Map<String, dynamic> json) =>
      OrdenLlevarRequest(
        idPedidoLlevar: json["idPedidoLlevar"] ?? 0,
        idEmpleado: json["idEmpleado"] ?? 0,
        idCliente: json["idCliente"] ?? 0,
        nombreCliente: json["nombresCompletosCliente"] ?? "",
        fechaPedido: DateTime.parse(json["fechaPedido"] ?? "2012-12-12"),
        estado: json["estado"] ?? 0,
        total: (json["total"]?.toDouble() ?? 0.0),
        cantidad: (json["cantidad"] ?? 0),
        idTipoPedido: json["idTipoPedido"] ?? 0,
        detallesLlevar: List<DetallesLlevar>.from((json["detallesLlevar"] ?? [])
            .map((x) => DetallesLlevar.fromJson(x))),
      );

  Map<String, dynamic> toJson() => {
        "idPedidoLlevar": idPedidoLlevar,
        "idEmpleado": idEmpleado,
        "idCliente": idCliente,
        "nombreCliente": nombreCliente,
        "fechaPedido": fechaPedido.toIso8601String(),
        "estado": estado,
        "total": total,
        "cantidad": cantidad,
        "idTipoPedido": idTipoPedido,
        "detallesLlevar":
            List<dynamic>.from(detallesLlevar.map((x) => x.toJson())),
      };
}

class DetallesLlevar {
  int idProducto;
  int cantidad;
  double precioUnitario;

  DetallesLlevar({
    required this.idProducto,
    required this.cantidad,
    required this.precioUnitario,
  });

  factory DetallesLlevar.fromJson(Map<String, dynamic> json) => DetallesLlevar(
        idProducto: json["idProducto"] ?? 0,
        cantidad: json["cantidad"] ?? 0,
        precioUnitario: (json["precioUnitario"] ?? 0).toDouble(),
      );

  Map<String, dynamic> toJson() => {
        "idProducto": idProducto,
        "cantidad": cantidad,
        "precioUnitario": precioUnitario,
      };
}
