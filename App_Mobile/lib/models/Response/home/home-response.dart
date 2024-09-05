// To parse this JSON data, do
//
//     final homeResponse = homeResponseFromJson(jsonString);

import 'dart:convert';

HomeResponse homeResponseFromJson(String str) => HomeResponse.fromJson(json.decode(str));

String homeResponseToJson(HomeResponse data) => json.encode(data.toJson());

class HomeResponse {
    int idTipoPedido;
    String descripcion;
    String descripcionSpa;

    HomeResponse({
        required this.idTipoPedido,
        required this.descripcion,
        required this.descripcionSpa,
    });

    factory HomeResponse.fromJson(Map<String, dynamic> json) => HomeResponse(
        idTipoPedido: json["idTipoPedido"],
        descripcion: json["descripcion"],
        descripcionSpa: json["descripcionSpa"],
    );

    Map<String, dynamic> toJson() => {
        "idTipoPedido": idTipoPedido,
        "descripcion": descripcion,
        "descripcionSpa": descripcionSpa,
    };
}
