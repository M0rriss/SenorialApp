import 'dart:convert';

MesasResponse mesasResponseFromJson(String str) => MesasResponse.fromJson(json.decode(str));

String mesasResponseToJson(MesasResponse data) => json.encode(data.toJson());

class MesasResponse {
    int idPedido;
    int idMesa;
    String nombre;
    double precio;
    int cantidad;
    int estado;

    MesasResponse({
        required this.idPedido,
        required this.idMesa,
        required this.nombre,
        required this.precio,
        required this.cantidad,
        required this.estado,
    });

    factory MesasResponse.fromJson(Map<String, dynamic> json) => MesasResponse(
        idPedido: json["idPedido"],
        idMesa: json["idMesa"],
        nombre: json["nombre"],
        precio: json["precio"].toDouble(),
        cantidad: json["cantidad"],
        estado: json["estado"]?? 0,
    );

    Map<String, dynamic> toJson() => {
        "idPedido": idPedido,
        "idMesa": idMesa,
        "nombre": nombre,
        "precio": precio,
        "cantidad": cantidad,
        "estado": estado,
    };
}