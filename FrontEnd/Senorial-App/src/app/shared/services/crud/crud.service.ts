import { HttpClient } from '@angular/common/http';
import { Inject, inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICrudGeneric } from './icrud-generic';

@Injectable({
  providedIn: 'root'
})
//T: respresenta los response
//Y: representa los request
export class CrudService <T,Y> implements ICrudGeneric<T,Y> {
    constructor(private _http:HttpClient,
        @Inject('url') public url:string,
    ){
        
    }
    getAll():Observable<T[]>{
        var res = this._http.get<T[]>(this.url);
        return res
    }
    crearRegistro(req:Y):Observable<T>{
        var res = this._http.post<T>(this.url,req);
        return res;
    }
    actulizarRegistro(req:Y):Observable<T>{
        var res = this._http.put<T>(this.url,req);
        return res;
    }
    deleteRegistro(req: number): Observable<boolean>{
        var res = this._http.delete<boolean>(`${this.url}?id=${req}`);
        return res;
    }
}