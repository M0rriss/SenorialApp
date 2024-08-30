// To parse this JSON data, do
//
//     final productResponse = productResponseFromJson(jsonString);

import 'dart:convert';

ProductResponse productResponseFromJson(String str) => ProductResponse.fromJson(json.decode(str));

String productResponseToJson(ProductResponse data) => json.encode(data.toJson());

class ProductResponse {
    int idProducto;
    String nombreProducto;
    String detalleProducto;
    String rutaImagen;
    int precioVenta;

    ProductResponse({
        required this.idProducto,
        required this.nombreProducto,
        required this.detalleProducto,
        required this.rutaImagen,
        required this.precioVenta,
    });

    factory ProductResponse.fromJson(Map<String, dynamic> json) => ProductResponse(
        idProducto: json["idProducto"],
        nombreProducto: json["nombreProducto"],
        detalleProducto: json["detalleProducto"],
        rutaImagen: json["rutaImagen"],
        precioVenta: json["precioVenta"],
    );

    Map<String, dynamic> toJson() => {
        "idProducto": idProducto,
        "nombreProducto": nombreProducto,
        "detalleProducto": detalleProducto,
        "rutaImagen": rutaImagen,
        "precioVenta": precioVenta,
    };
}
