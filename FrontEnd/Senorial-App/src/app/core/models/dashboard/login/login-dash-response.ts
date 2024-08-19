export interface LoginDashResponse {
    success: boolean;
    message: string;
    token: string;
    refreshToken: string;
    tokenCreated: string;
    tokenExpires: string;
    infoUser: InfoUserResponse;
}
export interface LoginEcommerceResponse {
    success: boolean;
    message: string;
    token: string;
    refreshToken: string;
    tokenCreated: string;
    tokenExpires: string;
    infoUsuario: InfoUserResponse;
}
export interface InfoUserResponse {
    idPersona: number;
    idRol: number;
    nombre: string;
    email: string;
    rol: string;
}