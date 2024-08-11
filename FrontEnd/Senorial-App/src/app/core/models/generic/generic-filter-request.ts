export interface GenericFilterRequest{
    numeroPagina: number;
    cantidad: number;
    filtros: FiltroRequest[];
}

export interface FiltroRequest{
    name: string;
      value: string;
}