import 'dart:convert';

HomeRequest homeRequestFromJson(String str) => HomeRequest.fromJson(json.decode(str));

String homeRequestToJson(HomeRequest data) => json.encode(data.toJson());

class HomeRequest {
    int idTipoPedido;
    String descripcion;
    String descripcionSpa;

    HomeRequest({
        required this.idTipoPedido,
        required this.descripcion,
        required this.descripcionSpa,
    });

    factory HomeRequest.fromJson(Map<String, dynamic> json) => HomeRequest(
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
