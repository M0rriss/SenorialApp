import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { urlUnidad } from "@app/core/constants/url-constant";
import { UnidadResponse } from "@app/core/models/dashboard/unidad/unidad-response";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
  })
export class UnidadService{
    constructor(protected http:HttpClient){}
    
    listarUnidades() : Observable<UnidadResponse[]>{
        var res = this.http.get<UnidadResponse[]>(urlUnidad.generic);
        return res;
    }
}