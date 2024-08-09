import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlSuministro } from '@app/core/constants/url-constant';
import { InsumoRequest } from '@app/core/models/dashboard/mantenimiento/insumos/insumo-request';
import { InsumoResponse } from '@app/core/models/dashboard/mantenimiento/insumos/insumo-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InsumoService {

  constructor(protected http:HttpClient) { 
    
  }

  listarInsumo(): Observable<InsumoResponse[]>{
    var res = this.http.get<InsumoResponse[]>(urlSuministro.listar);
    return res;
  }
  crearInsumo(req:InsumoRequest): Observable<InsumoResponse>{
    var res = this.http.post<InsumoResponse>(urlSuministro.crear,req);
    return res;
  }
  actulizarInsumo(req:InsumoRequest): Observable<InsumoResponse>{
    var res = this.http.put<InsumoResponse>(urlSuministro.actulizar,req);
    return res;
  }
  eliminarInsumo(idInsumo:number): Observable<boolean>{
    var res = this.http.delete<boolean>(`${urlSuministro}?id=${idInsumo}`);
    return res;
  }
}
