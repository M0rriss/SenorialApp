export interface DetalleMesaRequest {
    idPedidoMesa:   number;
    idMesaDetalle:  number;
    nombreProducto: string;
    cantidadItems:  number;
    subTotal:       number;
}
