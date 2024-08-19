import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { urlRol } from "@app/core/constants/url-constant";
import { RolRequest } from "@app/core/models/dashboard/roles/rol-request";
import { RolResponse } from "@app/core/models/dashboard/roles/rol-response";
import { CrudService } from "@app/shared/services/crud/crud.service";

@Injectable({
    providedIn: 'root'
})
export class RolesService extends CrudService<RolResponse,RolRequest> {
    constructor(protected http: HttpClient) {
        super(http,urlRol.generic);
     }
}