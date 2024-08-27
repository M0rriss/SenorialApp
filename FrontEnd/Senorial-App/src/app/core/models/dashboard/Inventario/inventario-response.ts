export interface InventarioResponse {
    idInventario: number;
    insumo:       string;
    stock:        number;
    fecha:        Date;
    unidadMedida: string;
    tipo:         string;
}