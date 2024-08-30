import 'package:m_senorial/models/auth/LoginResponse.dart';

class ResponseApi {
  final bool success;
  final String message;
  final LoginResponse? data;

  ResponseApi({required this.success, required this.message, this.data});

  factory ResponseApi.fromJson(Map<String, dynamic> json) {
    return ResponseApi(
      success: json['success'],
      message: json['message'],
      data: json['data'] != null ? LoginResponse.fromJson(json['data']) : null,
    );
  }
}