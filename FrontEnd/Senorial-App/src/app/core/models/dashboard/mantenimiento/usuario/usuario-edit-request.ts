export interface UsuarioEditRequest{
    idUsuario: number;
    file:File;
    email: string;
    password:string;
    role: number;
    contact:string;
    nuevo: boolean;
    nombreCompleto:string;
}
