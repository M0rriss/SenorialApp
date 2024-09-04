import 'dart:convert';

AuthResponse authResponseFromJson(String str) => AuthResponse.fromJson(json.decode(str));

String authResponseToJson(AuthResponse data) => json.encode(data.toJson());

class AuthResponse {
  bool success;
  String message;
  String token;
  String refreshToken;
  DateTime tokenCreated;
  DateTime tokenExpires;
  InfoUsuario infoUsuario;

  AuthResponse({
    required this.success,
    required this.message,
    required this.token,
    required this.refreshToken,
    required this.tokenCreated,
    required this.tokenExpires,
    required this.infoUsuario,
  });

  factory AuthResponse.fromJson(Map<String, dynamic> json) => AuthResponse(
    success: json["success"],
    message: json["message"],
    token: json["token"],
    refreshToken: json["refreshToken"],
    tokenCreated: DateTime.parse(json["tokenCreated"]),
    tokenExpires: DateTime.parse(json["tokenExpires"]),
    infoUsuario: InfoUsuario.fromJson(json["infoUsuario"]),
  );

  Map<String, dynamic> toJson() => {
    "success": success,
    "message": message,
    "token": token,
    "refreshToken": refreshToken,
    "tokenCreated": tokenCreated.toIso8601String(),
    "tokenExpires": tokenExpires.toIso8601String(),
    "infoUsuario": infoUsuario.toJson(),
  };
}


class InfoUsuario {
    int idPersona;
    int idRol;
    String nombre;
    String email;
    String rol;

    InfoUsuario({
        required this.idPersona,
        required this.idRol,
        required this.nombre,
        required this.email,
        required this.rol,
    });

    factory InfoUsuario.fromJson(Map<String, dynamic> json) => InfoUsuario(
        idPersona: json["idPersona"],
        idRol: json["idRol"],
        nombre: json["nombre"],
        email: json["email"],
        rol: json["rol"],
    );

    Map<String, dynamic> toJson() => {
        "idPersona": idPersona,
        "idRol": idRol,
        "nombre": nombre,
        "email": email,
        "rol": rol,
    };
}