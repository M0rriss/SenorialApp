import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { urlSalida } from "@app/core/constants/url-constant";
import { SalidaRequest } from "@app/core/models/dashboard/salida/salida-request";
import { CustomResponse } from "@app/core/models/generic/custom-response";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
  })
export class SalidaService{
    constructor(protected http:HttpClient){}

    registarSalida(req:SalidaRequest):Observable<CustomResponse>{
        var res = this.http.post<CustomResponse>(urlSalida.registrar,req);
        return res;
    }
}