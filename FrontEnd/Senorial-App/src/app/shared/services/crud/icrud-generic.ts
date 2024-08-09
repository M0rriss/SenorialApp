import { Observable } from "rxjs"

export interface ICrudGeneric<T,Y> {
    getAll():Observable<T[]>
    crearRegistro(req:Y):Observable<T>
    actulizarRegistro(req:Y):Observable<T>
    deleteRegistro(req: number): Observable<boolean>
}