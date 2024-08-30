class GenericFilterRequest {
  final int numeroPagina;
  final int cantidad;
  final List<FiltroRequest> filtros;

  GenericFilterRequest({
    required this.numeroPagina,
    required this.cantidad,
    required this.filtros,
  });
}

class FiltroRequest {
  final String name;
  final String value;

  FiltroRequest({
    required this.name,
    required this.value,
  });
}