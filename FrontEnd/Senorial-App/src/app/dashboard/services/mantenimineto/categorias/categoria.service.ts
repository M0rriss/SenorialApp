import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoriaResponse, CategoriasResponse } from '../../../../core/models/dashboard/mantenimiento/categoria/categoria-response';
import { urlCategoria } from '../../../../core/constants/url-constant';
import { CategoriaEcommerceResponse } from '@app/core/models/dashboard/mantenimiento/categoria/categoria-ecommerce-response';
import { CategoriaRequest } from '@app/core/models/dashboard/mantenimiento/categoria/categoria-request';
import { CustomResponse } from '@app/core/models/generic/custom-response';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  constructor(protected http:HttpClient) { }

  listarCategoria(): Observable<CategoriaResponse[]>{
    
    var res = this.http.get<CategoriaResponse[]>(urlCategoria.listar);
    return res;
  }
  listarTodasCategorias(): Observable<CategoriasResponse[]>{
    var res = this.http.get<CategoriasResponse[]>(urlCategoria.listv2);
  return res;
  }

  listarEcommerCategoria(): Observable<CategoriaEcommerceResponse[]>{
    var res = this.http.get<CategoriaEcommerceResponse[]>(urlCategoria.listEcommer);
    return res;
  }

  buscarSubCategoria(idCategoria: number):Observable<CategoriaEcommerceResponse[]>{
    var res = this.http.get<CategoriaEcommerceResponse[]>(`${urlCategoria.filttraEcommer}?idCategoria=${idCategoria}`)
    return res;
  }

  listarSubCategoria() : Observable<CategoriasResponse[]>{
    var res = this.http.get<CategoriasResponse[]>(urlCategoria.listarSub)
    return res;
  }

  crearCategoriaPadre(req:CategoriaRequest) : Observable<CustomResponse>{
    var res = this.http.post<CustomResponse>(urlCategoria.crearPadre,req);
    return res;
  }

  crearSubCategoria(req:CategoriaRequest) : Observable<CustomResponse>{
    var res = this.http.post<CustomResponse>(urlCategoria.crearSub,req);
    return res;
  }

  actulizarCategoriaPadre(req:CategoriaRequest) : Observable<CustomResponse>{
    var res = this.http.put<CustomResponse>(urlCategoria.actulizarPadre,req);
    return res;
  }

  actulizarSubCategoria(req:CategoriaRequest) : Observable<CustomResponse>{
    var res = this.http.put<CustomResponse>(urlCategoria.actulizarSub,req);
    return res;
  }
}
