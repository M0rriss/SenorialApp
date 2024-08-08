export interface CategoriaResponse{
    categoria: string;
    subcategorias: string;
    estado: string;
}
export interface CategoriasResponse{
    idCategoria: number,
    nombre: string,
    idCategoriaPadre: number,
    estado: boolean,
    estadoDescripcion: string
}