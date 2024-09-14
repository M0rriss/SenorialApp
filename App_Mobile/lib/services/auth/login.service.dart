import 'package:senorial/models/auth/LoginRequest.dart';
import 'package:senorial/models/auth/LoginResponse.dart';
import 'package:senorial/models/auth/authResponse.dart';
import 'package:senorial/services/crud_service.dart';
import 'package:shared_preferences/shared_preferences.dart';


class AuthService extends CrudService<LoginRequest, LoginResponse> {
  AuthService({
    required super.ruta,
    required super.dio
    });

  Future<void> guardarNombreUsuario(AuthResponse authResponse) async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    String nombre = authResponse.infoUsuario.nombre;
    await prefs.setString('nombreUsuario', nombre);
  }

  // Método para obtener el nombre del usuario desde SharedPreferences
  Future<String> obtenerNombreUsuario() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    return prefs.getString('nombreUsuario') ?? ''; // Retorna una cadena vacía si no hay nombre guardado
  }

   // Método para realizar el login y guardar la información del usuario
  Future<void> login(String username, String password) async {
    final response = await dio.post(ruta, data: {
      'username': username,
      'password': password,
    });

    // Deserializa la respuesta
    final loginResponse = LoginResponse.fromJson(response.data);

    // Verifica si la respuesta fue exitosa
    if (loginResponse.login.success) {
      // Guarda el nombre del usuario en SharedPreferences
      await guardarNombreUsuario(loginResponse.login);
    } else {
      throw Exception('Error en el inicio de sesión: ${loginResponse.login.message}');
    }
  }

}