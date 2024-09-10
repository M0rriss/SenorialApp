import 'dart:convert';

OrdenLlevarRequest ordenLlevarRequestFromJson(String str) => OrdenLlevarRequest.fromJson(json.decode(str));

String ordenLlevarRequestToJson(OrdenLlevarRequest data) => json.encode(data.toJson());

class OrdenLlevarRequest {
    int idPedidoLlevar;
    int idEmpleado;
    int idCliente;
    String nombreCliente;
    DateTime fechaPedido;
    int estado;
    double total;
    int idTipoPedido;
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
    });

    factory OrdenLlevarRequest.fromJson(Map<String, dynamic> json) => OrdenLlevarRequest(
        idPedidoLlevar: json["idPedidoLlevar"],
        idEmpleado: json["idEmpleado"],
        idCliente: json["idCliente"],
        nombreCliente: json["nombreCliente"],
        fechaPedido: DateTime.parse(json["fechaPedido"]),
        estado: json["estado"],
        total: json["total"].toDouble(),
        idTipoPedido: json["idTipoPedido"],
        detallesLlevar: List<DetallesLlevar>.from(json["detallesLlevar"].map((x) => DetallesLlevar.fromJson(x))),
    );

    Map<String, dynamic> toJson() => {
        "idPedidoLlevar": idPedidoLlevar,
        "idEmpleado": idEmpleado,
        "idCliente": idCliente,
        "nombreCliente": nombreCliente,
        "fechaPedido": fechaPedido.toIso8601String(),
        "estado": estado,
        "total": total,
        "idTipoPedido": idTipoPedido,
        "detallesLlevar": List<dynamic>.from(detallesLlevar.map((x) => x.toJson())),
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
        idProducto: json["idProducto"],
        cantidad: json["cantidad"],
        precioUnitario: json["precioUnitario"].toDouble(),
    );

    Map<String, dynamic> toJson() => {
        "idProducto": idProducto,
        "cantidad": cantidad,
        "precioUnitario": precioUnitario,
    };
}
