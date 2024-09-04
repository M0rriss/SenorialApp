class CategoriasRequest
 {
    int idCategoria;
    String nombre;
    dynamic idCategoriaPadre;
    bool estado;
    String estadoDescripcion;

    CategoriasRequest
    ({
        required this.idCategoria,
        required this.nombre,
        required this.idCategoriaPadre,
        required this.estado,
        required this.estadoDescripcion,
    });

    factory CategoriasRequest
    .fromJson(Map<String, dynamic> json) => CategoriasRequest
    (
        idCategoria: json["idCategoria"],
        nombre: json["nombre"],
        idCategoriaPadre: json["idCategoriaPadre"],
        estado: json["estado"],
        estadoDescripcion: json["estadoDescripcion"],
    );

    Map<String, dynamic> toJson() => {
        "idCategoria": idCategoria,
        "nombre": nombre,
        "idCategoriaPadre": idCategoriaPadre,
        "estado": estado,
        "estadoDescripcion": estadoDescripcion,
    };
}
