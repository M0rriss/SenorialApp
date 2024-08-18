import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { urlProducto } from "@app/core/constants/url-constant";
import { ProductDashResponse } from "@app/core/models/dashboard/mantenimiento/product/product-dash-response";
import { ProductRequest } from "@app/core/models/dashboard/mantenimiento/product/product-request";
import { ProductResponse } from "@app/core/models/dashboard/mantenimiento/product/product-response";
import { CustomResponse } from "@app/core/models/generic/custom-response";
import { GenericFilterRequest } from "@app/core/models/generic/generic-filter-request";
import { GenericFilterResponse } from "@app/core/models/generic/generic-filter-response";
import { CrudService } from "@app/shared/services/crud/crud.service";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class ProductoService extends CrudService<ProductResponse,ProductRequest>{
    constructor(protected http:HttpClient){
        super(http, urlProducto.generic);
    }
    listarProductos(req: GenericFilterRequest) : Observable<GenericFilterResponse<ProductDashResponse>>{
        var res = this.http.post<GenericFilterResponse<ProductDashResponse>>(urlProducto.dashboard,req);
        return res;
    }
    crearProducto(formData:FormData):Observable<CustomResponse>{
        var res = this.http.post<CustomResponse>(urlProducto.create,formData);
        return res;
    }

    edidtarProducto(formData:FormData):Observable<CustomResponse>{
        var res = this.http.put<CustomResponse>(urlProducto.update,formData);
        return res;
    }
}