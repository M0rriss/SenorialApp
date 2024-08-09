import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlMesa } from '@app/core/constants/url-constant';
import { MesaRequest } from '@app/core/models/dashboard/mantenimiento/mesas/mesa-request';
import { MesaResponse } from '@app/core/models/dashboard/mantenimiento/mesas/mesa-response';
import { CrudService } from '@app/shared/services/crud/crud.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MesaService extends CrudService<MesaResponse,MesaRequest> {

  constructor(protected http:HttpClient) { super(http,urlMesa.generic) }

  // listarMesas():Observable<MesaResponse[]>{
  //   var res = this.http.get<MesaResponse[]>(urlMesa.listar);
  //   return res;
  // }
  // crearMesa(req:MesaRequest):Observable<MesaResponse>{
  //   var res = this.http.post<MesaResponse>(urlMesa.crear,req);
  //   return res;
  // }
  // updateMesa(req:MesaRequest):Observable<MesaResponse>{
  //   var res = this.http.put<MesaResponse>(urlMesa.actulizar,req);
  //   return res;
  // }
  // deleteMesa(idMesa:number):Observable<boolean>{
  //   var res = this.http.delete<boolean>(`${urlMesa.delete}?id=${idMesa}`);
  //   return res;
  // }
}
