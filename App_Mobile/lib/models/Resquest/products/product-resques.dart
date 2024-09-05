// filtro-request.dart

class FiltroRequest {
  String name;
  String value;

  FiltroRequest({required this.name, required this.value});

  Map<String, String> toJson() {
    return {
      'name': name,
      'value': value,
    };
  }
}
