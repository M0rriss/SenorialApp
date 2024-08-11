export interface ProductEditRequest{
    idProducto: number;
    nombre: string;
    descripcion: string;
    idCategoria: number;
    derivar: string;
    precioVenta: number;
}