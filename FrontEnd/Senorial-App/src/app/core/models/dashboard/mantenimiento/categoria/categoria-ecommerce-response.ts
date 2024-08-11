export interface CategoriaEcommerceResponse{
    idCategoria: number;
    nombre: string;
    idCategoriaPadre?: number;
    estado: string;
    estadoDescripcion: string;
    ruta:string;
}