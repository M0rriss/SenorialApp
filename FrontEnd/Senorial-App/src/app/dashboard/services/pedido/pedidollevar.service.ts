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

public buscardetallePedidoLlevar(idPedidoLlevar:number):Observable<DetallePedidoLlevarResponse[]>{
    return this.http.get<DetallePedidoLlevarResponse[]>(`${urlPedidoLlevar.detalle}?idPedidoLlevar=${idPedidoLlevar}`)
}

public pedidoListoLlevar(idPedidoLlevar:number) : Observable<CustomResponse>{
    return this.http.put<CustomResponse>(`${urlPedidoLlevar.listo}?idPedidoLlevar=${idPedidoLlevar}`,{});
}

public cancelarPedidoLlevar(idPedidoLlevar:number) : Observable<CustomResponse>{
    return this.http.delete<CustomResponse>(`${urlPedidoLlevar.cancelar}?idPedidoLlevar=${idPedidoLlevar}`,{});
}


}
