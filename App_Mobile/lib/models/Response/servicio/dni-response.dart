class DniResponse {
    bool success;
    String dni;
    String nombres;
    String apellidoPaterno;
    String apellidoMaterno;
    String codVerifica;

    DniResponse({
        required this.success,
        required this.dni,
        required this.nombres,
        required this.apellidoPaterno,
        required this.apellidoMaterno,
        required this.codVerifica,
    });

    factory DniResponse.fromJson(Map<String, dynamic> json) => DniResponse(
        success: json["success"],
        dni: json["dni"],
        nombres: json["nombres"],
        apellidoPaterno: json["apellidoPaterno"],
        apellidoMaterno: json["apellidoMaterno"],
        codVerifica: json["codVerifica"],
    );

    Map<String, dynamic> toJson() => {
        "success": success,
        "dni": dni,
        "nombres": nombres,
        "apellidoPaterno": apellidoPaterno,
        "apellidoMaterno": apellidoMaterno,
        "codVerifica": codVerifica,
    };
}