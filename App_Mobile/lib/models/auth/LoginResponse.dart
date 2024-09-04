import 'package:m_senorial/models/auth/authResponse.dart';
import 'package:m_senorial/models/generic/custom-response.dart';

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