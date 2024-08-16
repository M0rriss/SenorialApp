import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlSuministro } from '@app/core/constants/url-constant';
import { FiltroInsumoResponse } from '@app/core/models/dashboard/mantenimiento/insumos/filtro-insumo-response';
import { InsumoRequest } from '@app/core/models/dashboard/mantenimiento/insumos/insumo-request';
import { InsumoResponse } from '@app/core/models/dashboard/mantenimiento/insumos/insumo-response';
import { CustomResponse } from '@app/core/models/generic/custom-response';
import { GenericFilterRequest } from '@app/core/models/generic/generic-filter-request';
import { GenericFilterResponse } from '@app/core/models/generic/generic-filter-response';
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
  crearInsumo(req:InsumoRequest): Observable<CustomResponse>{
    var res = this.http.post<CustomResponse>(urlSuministro.crear,req);
    return res;
  }
  actulizarInsumo(req:InsumoRequest): Observable<CustomResponse>{
    var res = this.http.put<CustomResponse>(urlSuministro.actulizar,req);
    return res;
  }
  eliminarInsumo(idInsumo:number): Observable<boolean>{
    var res = this.http.delete<boolean>(`${urlSuministro}?id=${idInsumo}`);
    return res;
  }

  filtrarInsumos(req: GenericFilterRequest):Observable<GenericFilterResponse<FiltroInsumoResponse>>{
    var res = this.http.post<GenericFilterResponse<FiltroInsumoResponse>>(urlSuministro.filtro,req);
    return res;
  }
}
