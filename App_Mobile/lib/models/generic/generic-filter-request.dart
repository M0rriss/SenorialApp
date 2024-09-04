// generic-filter-request.dart
import 'package:m_senorial/models/Resquest/products/product-resques.dart';

class GenericFilterRequest {
  int numeroPagina;
  int cantidad;
  List<FiltroRequest> filtros;

  GenericFilterRequest({
    required this.numeroPagina,
    required this.cantidad,
    required this.filtros,
  });

  Map<String, dynamic> toJson() {
    return {
      'numeroPagina': numeroPagina,
      'cantidad': cantidad,
      'filtros': filtros.map((filtro) => filtro.toJson()).toList(),
    };
  }
}
