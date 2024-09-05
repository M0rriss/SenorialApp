class CustomResponse {
  String code;
  String message;

  CustomResponse({
    required this.code, 
    required this.message
    });
    factory CustomResponse.fromJson(Map<String, dynamic> json) => CustomResponse(
        message: json["mensaje"],
        code: json["codigo"],
        
      );

  Map<String, dynamic> toJson() => {
        "mensaje": message,
        "codigo": code,
      };
} 
