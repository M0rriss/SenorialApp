import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { urlEntradas } from "@app/core/constants/url-constant";
import { EntradaRequest } from "@app/core/models/dashboard/entrada/entrada-request";
import { CustomResponse } from "@app/core/models/generic/custom-response";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
  })
  export class EntradaService{
    constructor(protected http:HttpClient){}

    registarEntrada(req:EntradaRequest) : Observable<CustomResponse>{
        var res = this.http.post<CustomResponse>(urlEntradas.registrar,req);
        return res;
    }
  }