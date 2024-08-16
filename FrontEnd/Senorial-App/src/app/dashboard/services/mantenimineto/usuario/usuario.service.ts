import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { urlUsuario } from "@app/core/constants/url-constant";
import { UsuarioAddRequest } from "@app/core/models/dashboard/mantenimiento/usuario/usuario-add-request";
import { UsuarioEditRequest } from "@app/core/models/dashboard/mantenimiento/usuario/usuario-edit-request";
import { UsuarioResponse } from "@app/core/models/dashboard/mantenimiento/usuario/usuario-response";
import { CustomResponse } from "@app/core/models/generic/custom-response";
import { GenericFilterRequest } from "@app/core/models/generic/generic-filter-request";
import { GenericFilterResponse } from "@app/core/models/generic/generic-filter-response";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class UsuarioService{
    constructor(protected http:HttpClient){}
    listarUsuarios(req:GenericFilterRequest):Observable<GenericFilterResponse<UsuarioResponse>>{
        var res = this.http.post<GenericFilterResponse<UsuarioResponse>>(urlUsuario.filtro,req);
        return res;
    }

    crearUsuario(req:UsuarioAddRequest) : Observable<CustomResponse>{
        //Cargar datos
        const formData = new FormData();
        formData.append("File",req.file);
        formData.append("Email",req.email);
        formData.append("Password",req.password);
        formData.append("Role",req.role.toString());
        formData.append("Contact",req.contact);

        //Consumo de api
        var res = this.http.post<CustomResponse>(urlUsuario.create,formData);
        return res;
    }

    actulizarUsuario(req:UsuarioEditRequest): Observable<CustomResponse>{
        //Cargar datos
        const formData = new FormData();
        formData.append("IdUsuario",req.idUsuario.toString());
        formData.append("File",req.file);
        formData.append("Email",req.email);
        formData.append("Password",req.password);
        formData.append("Role",req.role.toString());
        formData.append("Contact",req.contact);
        formData.append("Nuevo",`${req.nuevo}`);

        //CONSUMO APIS
        var res = this.http.put<CustomResponse>(urlUsuario.update, formData);
        return res;
    }
}