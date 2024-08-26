import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlLocal } from '@app/core/constants/url-constant';
import { DetalleMesaRequest } from '@app/core/models/dashboard/local/detalle/detalle-mesa-request';
import { DetalleMesaResponse } from '@app/core/models/dashboard/local/detalle/detalle-mesa-response';
import { LocalMesaResponse } from '@app/core/models/dashboard/local/local-mesa-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MesaslocalService {

  constructor(
    protected http:HttpClient
    ){ }
    listarMesasLocal$(): Observable<LocalMesaResponse[]>{
      let res = this.http.get<LocalMesaResponse[]>(urlLocal.listar);
      return res;
    }
    //DETALLE
    listarDetalleProductosMesas$(IdMesa: number, IdPedido: number): Observable<DetalleMesaResponse[]>{
      let res = this.http.get<DetalleMesaResponse[]>(`${urlLocal.listarDetalle}?IdMesa=${IdMesa}&IdPedido=${IdPedido}`);
      return res;
    }
}
