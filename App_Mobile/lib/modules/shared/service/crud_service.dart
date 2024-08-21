import 'dart:convert';
import 'package:http/http.dart' as http;

class ApiService<T> {
  String endpoint = "https://localhost:7283/api/";

  ApiService(this.endpoint);

  Future<T> get(String path) async {
    final response = await http.get(Uri.parse('$endpoint$path'));

    if (response.statusCode == 200) {
      return jsonDecode(response.body);
    } else {
      throw Exception('Failed to load data');
    }
  }

  Future<T> post(String path, dynamic data) async {
    final response = await http.post(
      Uri.parse('$endpoint$path'),
      body: jsonEncode(data),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
    );

    if (response.statusCode == 200) {
      return jsonDecode(response.body);
    } else {
      throw Exception('Failed to save data');
    }
  }

  Future<T> put(String path, dynamic data) async {
    final response = await http.put(
      Uri.parse('$endpoint$path'),
      body: jsonEncode(data),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
    );

    if (response.statusCode == 200) {
      return jsonDecode(response.body);
    } else {
      throw Exception('Failed to edit data');
    }
  }

  Future<T> delete(String path) async {
    final response = await http.delete(Uri.parse('$endpoint$path'));

    if (response.statusCode == 200) {
      return jsonDecode(response.body);
    } else {
      throw Exception('Failed to delete data');
    }
  }
}