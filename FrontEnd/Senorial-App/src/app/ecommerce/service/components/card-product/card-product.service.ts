import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { urlProducto } from "@app/core/constants/url-constant";
import { CardProductResponse } from "@app/core/models/ecommerce/components/card-product/card-product-response";
import { GenericFilterRequest } from "@app/core/models/generic/generic-filter-request";
import { GenericFilterResponse } from "@app/core/models/generic/generic-filter-response";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
  })

export class CardProductService {
    constructor(protected http:HttpClient){}

    listarProductos(req: GenericFilterRequest) : Observable<GenericFilterResponse<CardProductResponse>>{
        var res = this.http.post<GenericFilterResponse<CardProductResponse>>(urlProducto.ecommerce,req);
        return res;
    }
}