class GenericFilterResponse<T> {
   int totalRegistros;
   List<T> lista;

  GenericFilterResponse({
    required this.totalRegistros,
    required this.lista,
  });
}