class GenericFilterResponse<T> {
  final int totalRegistros;
  final List<T> lista;

  GenericFilterResponse({
    required this.totalRegistros,
    required this.lista,
  });
}