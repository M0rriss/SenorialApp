import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { urlInventario } from "@app/core/constants/url-constant";
import { BusqueInventarioInsumoResponse } from "@app/core/models/dashboard/Inventario/busqueda-inventario-insumo-response";
import { InventarioDetalleResponse } from "@app/core/models/dashboard/Inventario/inventario-detalle-response";
import { InventarioResponse } from "@app/core/models/dashboard/Inventario/inventario-response";
import { CustomResponse } from "@app/core/models/generic/custom-response";
import { GenericFilterResponse } from "@app/core/models/generic/generic-filter-response";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
  })
  export class InventoryService{
    constructor(protected http:HttpClient){}

    listarInventario(page:number, pagesize:number, insumo:string):Observable<GenericFilterResponse<InventarioResponse>>{
        if(insumo == ''){
            var res = this.http.get<GenericFilterResponse<InventarioResponse>>(`${urlInventario.listar}?page=${page}&pagesize=${pagesize}`);
        }
        else{
            var res = this.http.get<GenericFilterResponse<InventarioResponse>>(`${urlInventario.listar}?page=${page}&pagesize=${pagesize}$insumo=${insumo}`);
        }
        return res;
    }

    listarInventarioDetalle(page:number, pagesize:number, insumo:string) : Observable<GenericFilterResponse<InventarioDetalleResponse>>{
        var res = this.http.get<GenericFilterResponse<InventarioDetalleResponse>>(`${urlInventario.detalle}?page=${page}&pagesize=${pagesize}`);
        return res;
    }

    buscarInsumoInvetario(idInsumo: number): Observable<BusqueInventarioInsumoResponse>{
        var res = this.http.get<BusqueInventarioInsumoResponse>(`${urlInventario.buscar}?idInsumo=${idInsumo}`);
        return res;
    }

    eliminarInsumoInventario(idInsumo:number):Observable<CustomResponse>{
        var res = this.http.delete<CustomResponse>(`${urlInventario.eliminar}?idInsumo=${idInsumo}`);
        return res;
    }
  }