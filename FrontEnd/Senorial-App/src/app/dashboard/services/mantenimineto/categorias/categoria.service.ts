import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoriaResponse, CategoriasResponse } from '../../../../core/models/dashboard/mantenimiento/categoria/categoria-response';
import { urlCategoria } from '../../../../core/constants/url-constant';
import { CategoriaEcommerceResponse } from '@app/core/models/dashboard/mantenimiento/categoria/categoria-ecommerce-response';

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
}
