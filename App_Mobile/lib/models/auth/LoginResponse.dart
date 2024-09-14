import 'package:senorial/models/auth/authResponse.dart';
import 'package:senorial/models/generic/custom-response.dart';

class LoginResponse {
  CustomResponse mensage;
  AuthResponse login;

  LoginResponse({
    required this.mensage,
    required this.login,
  });

  factory LoginResponse.fromJson(Map<String, dynamic> json) => LoginResponse(
        mensage: CustomResponse.fromJson(json["mensage"]),
        login: AuthResponse.fromJson(json["login"]),
      );

  Map<String, dynamic> toJson() => {
        "mensage": mensage.toJson(),
        "login": login.toJson(),
      };
}