import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { urlPedido } from "@app/core/constants/url-constant";
import { DetallePedidoResponse } from "@app/core/models/dashboard/pedido/detalle-pedido-response";
import { PedidoLocalResponse } from "@app/core/models/dashboard/pedido/pedido-local-response";
import { CustomResponse } from "@app/core/models/generic/custom-response";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class PedidoService{
    constructor(protected http:HttpClient){}

    public listarPedidos():Observable<PedidoLocalResponse[]>{
        return this.http.get<PedidoLocalResponse[]>(urlPedido.list);
    }
    
    public buscardetallePedido(idPedido:number):Observable<DetallePedidoResponse[]>{
        return this.http.get<DetallePedidoResponse[]>(`${urlPedido.detalle}?idPedido=${idPedido}`)
    }

    public pedidoListo(idPedido:number) : Observable<CustomResponse>{
        return this.http.put<CustomResponse>(`${urlPedido.listo}?idPedido=${idPedido}`,{}); 
    }
    
    public cancelarPedido(idPedido:number) : Observable<CustomResponse>{
        return this.http.delete<CustomResponse>(`${urlPedido.listo}?idPedido=${idPedido}`,{}); 
    }
}