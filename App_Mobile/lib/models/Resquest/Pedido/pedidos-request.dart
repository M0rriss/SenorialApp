// To parse this JSON data, do
//
//     final pedidosRequest = pedidosRequestFromJson(jsonString);

import 'dart:convert';

List<PedidosRequest> pedidosRequestFromJson(String str) => List<PedidosRequest>.from(json.decode(str).map((x) => PedidosRequest.fromJson(x)));

String pedidosRequestToJson(List<PedidosRequest> data) => json.encode(List<dynamic>.from(data.map((x) => x.toJson())));

class PedidosRequest {
    int idPedido;
    int idEmpleado;
    int idMesa;
    String mesaNombre;
    DateTime fechaPedido;
    int estado;
    double total;
    int idTipoPedido;
    List<Detalle> detalles;

    PedidosRequest({
        required this.idPedido,
        required this.idEmpleado,
        required this.idMesa,
        required this.mesaNombre,
        required this.fechaPedido,
        required this.estado,
        required this.total,
        required this.idTipoPedido,
        required this.detalles,
    });

    factory PedidosRequest.fromJson(Map<String, dynamic> json) => PedidosRequest(
        idPedido: json["idPedido"],
        idEmpleado: json["idEmpleado"],
        idMesa: json["idMesa"],
        mesaNombre: json["mesaNombre"],
        fechaPedido: DateTime.parse(json["fechaPedido"]),
        estado: json["estado"],
        total: json["total"],
        idTipoPedido: json["idTipoPedido"],
        detalles: List<Detalle>.from(json["detalles"].map((x) => Detalle.fromJson(x))),
    );

    Map<String, dynamic> toJson() => {
        "idPedido": idPedido,
        "idEmpleado": idEmpleado,
        "idMesa": idMesa,
        "mesaNombre": mesaNombre,
        "fechaPedido": fechaPedido.toIso8601String(),
        "estado": estado,
        "total": total,
        "idTipoPedido": idTipoPedido,
        "detalles": List<dynamic>.from(detalles.map((x) => x.toJson())),
    };
}

class Detalle {
    int idDetallePedido;
    int idProducto;
    String productoNombre;
    int cantidad;
    double precioUnitario;

    Detalle({
        required this.idDetallePedido,
        required this.idProducto,
        required this.productoNombre,
        required this.cantidad,
        required this.precioUnitario,
    });

    factory Detalle.fromJson(Map<String, dynamic> json) => Detalle(
        idDetallePedido: json["idDetallePedido"],
        idProducto: json["idProducto"],
        productoNombre: json["productoNombre"],
        cantidad: json["cantidad"],
        precioUnitario: json["precioUnitario"],
    );

    Map<String, dynamic> toJson() => {
        "idDetallePedido": idDetallePedido,
        "idProducto": idProducto,
        "productoNombre": productoNombre,
        "cantidad": cantidad,
        "precioUnitario": precioUnitario,
    };
}
