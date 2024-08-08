export interface LoginRequest {
  email:    string;
  password: string;
}
export interface LoginResponse {
  success:      boolean;
  message:      string;
  token:        string;
  refreshToken: string;
  tokenCreated: Date;
  tokenExpires: Date;
  usuario:      Usuario;
  roles:        Roles;
  persona:      { [key: string]: number | null };
}

export interface Roles {
  idRol:       number;
  nombre:      null;
  abreviacion: null;
  descripcion: null;
  estado:      null;
}

export interface Usuario {
  idUsuario:          number;
  userName:           null;
  password:           null;
  createdAt:          null;
  idPersona:          number;
  updateAt:           null;
  idRol:              number;
  email:              string;
  cambiarPassword:    null;
  codigoRecuperacion: string;
}
