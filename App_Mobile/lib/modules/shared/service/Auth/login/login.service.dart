import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:m_senorial/modules/request/loginrequest/LoginRequest.dart';
import 'package:m_senorial/modules/response/loginresponse/ResponseApi.dart';

class UsuarioServicio {
  static const String endpoint = "https://localhost:7283/api/";

  Future<ResponseApi> iniciarSesion(LoginRequest request) async {
    final response = await http.post(
      Uri.parse('$endpoint' + 'Auth/Login/Mobile'),
      body: jsonEncode(request.toJson()),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
    );

    if (response.statusCode == 200) {
      return ResponseApi.fromJson(jsonDecode(response.body));
    } else {
      throw Exception('Failed to load data');
    }
  }

  Future<ResponseApi> getUsuarios() async {
    final response = await http.get(
      Uri.parse('$endpoint' + 'Usuario/Lista'),
    );

    if (response.statusCode == 200) {
      return ResponseApi.fromJson(jsonDecode(response.body));
    } else {
      throw Exception('Failed to load data');
    }
  }

  // Future<ResponseApi> saveUsuario(Usuario request) async {
  //   final response = await http.post(
  //     Uri.parse('$endpoint' + 'Usuario/Guardar'),
  //     body: jsonEncode(request.toJson()),
  //     headers: <String, String>{
  //       'Content-Type': 'application/json; charset=UTF-8',
  //     },
  //   );

  //   if (response.statusCode == 200) {
  //     return ResponseApi.fromJson(jsonDecode(response.body));
  //   } else {
  //     throw Exception('Failed to save data');
  //   }
  // }

  // Future<ResponseApi> editUsuario(Usuario request) async {
  //   final response = await http.put(
  //     Uri.parse('$endpoint' + 'Usuario/Editar'),
  //     body: jsonEncode(request.toJson()),
  //     headers: <String, String>{
  //       'Content-Type': 'application/json; charset=UTF-8',
  //     },
  //   );

  //   if (response.statusCode == 200) {
  //     return ResponseApi.fromJson(jsonDecode(response.body));
  //   } else {
  //     throw Exception('Failed to edit data');
  //   }
  // }

  // Future<ResponseApi> deleteUsuario(int id) async {
  //   final response = await http.delete(
  //     Uri.parse('$endpoint' + 'Usuario/Eliminar/$id'),
  //   );

  //   if (response.statusCode == 200) {
  //     return ResponseApi.fromJson(jsonDecode(response.body));
  //   } else {
  //     throw Exception('Failed to delete data');
  //   }
  // }
}