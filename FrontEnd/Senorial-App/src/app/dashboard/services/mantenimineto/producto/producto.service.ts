import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { urlProducto } from "@app/core/constants/url-constant";
import { ProductRequest } from "@app/core/models/dashboard/mantenimiento/product/product-request";
import { ProductResponse } from "@app/core/models/dashboard/mantenimiento/product/product-response";
import { CrudService } from "@app/shared/services/crud/crud.service";

@Injectable({
    providedIn: 'root'
})
export class ProductoService extends CrudService<ProductResponse,ProductRequest>{
    constructor(protected http:HttpClient){
        super(http, urlProducto.generic);
    }
}