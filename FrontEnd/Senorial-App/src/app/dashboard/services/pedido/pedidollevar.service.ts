import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlPedidoLlevar } from '@app/core/constants/url-constant';
import { DetallePedidoLlevarResponse } from '@app/core/models/dashboard/pedido/detalle-pedido-llevar-response';
import { PedidoLlevarResponse } from '@app/core/models/dashboard/pedido/pedido-llevar-response';
import { CustomResponse } from '@app/core/models/generic/custom-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PedidollevarService {

  constructor(protected http:HttpClient){}

  public listarPedidosLlevar():Observable<PedidoLlevarResponse[]>{
    return this.http.get<PedidoLlevarResponse[]>(urlPedidoLlevar.list);
}

public buscardetallePedidoLlevar(idPedido:number):Observable<DetallePedidoLlevarResponse[]>{
    return this.http.get<DetallePedidoLlevarResponse[]>(`${urlPedidoLlevar.detalle}?idPedido=${idPedido}`)
}

public pedidoListoLlevar(idPedido:number) : Observable<CustomResponse>{
    return this.http.put<CustomResponse>(`${urlPedidoLlevar.listo}?idPedido=${idPedido}`,{});
}

public cancelarPedidoLlevar(idPedido:number) : Observable<CustomResponse>{
    return this.http.delete<CustomResponse>(`${urlPedidoLlevar.cancelar}?idPedido=${idPedido}`,{});
}


}
