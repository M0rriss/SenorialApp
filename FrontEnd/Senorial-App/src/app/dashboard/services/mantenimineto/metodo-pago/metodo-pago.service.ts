import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlMetodoPago } from '@app/core/constants/url-constant';
import { MetodoPagoRequest } from '@app/core/models/dashboard/mantenimiento/metodo-pago/metodo-pago-request';
import { MetodoPagoResponse } from '@app/core/models/dashboard/mantenimiento/metodo-pago/metodo-pago-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MetodoPagoService {

  constructor(protected http:HttpClient) { }
  listarMetodoPagos():Observable<MetodoPagoResponse[]>{
    var res = this.http.get<MetodoPagoResponse[]>(urlMetodoPago.listar);
    return res;
  }
  crearMetodoPago(req:MetodoPagoRequest):Observable<MetodoPagoResponse>{
    var res = this.http.post<MetodoPagoResponse>(urlMetodoPago.crear,req);
    return res;
  }
  updateMetodoPago(req:MetodoPagoRequest):Observable<MetodoPagoResponse>{
    var res = this.http.put<MetodoPagoResponse>(urlMetodoPago.actulizar,req);
    return res;
  }
  deleteMetodoPago(idMetodoPago:number):Observable<boolean>{
    var res = this.http.delete<boolean>(`${urlMetodoPago.delete}?id=${idMetodoPago}`);
    return res;
  }
}
