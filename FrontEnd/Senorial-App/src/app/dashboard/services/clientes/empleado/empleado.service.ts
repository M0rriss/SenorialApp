import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlEmplados } from '@app/core/constants/url-constant';
import { EmpleadoRequest } from '@app/core/models/dashboard/empleados/empleado-request';
import { EmpleadoResponse } from '@app/core/models/dashboard/empleados/empleado-response';
import { CrudService } from '@app/shared/services/crud/crud.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {

  constructor(protected http: HttpClient) { }

  listarEmpleado(): Observable<EmpleadoResponse[]> {
    let res = this.http.get<EmpleadoResponse[]>(urlEmplados.listar);
    return res;
  }

  crearEmpleado(req: EmpleadoRequest): Observable<EmpleadoResponse> {
    let res = this.http.post<EmpleadoResponse>(urlEmplados.crear, req);
    return res;
  }

  actualizarEmpleado(req: EmpleadoRequest): Observable<EmpleadoResponse> {
    let res = this.http.put<EmpleadoResponse>(urlEmplados.actualizar, req);
    return res;
  }
}
