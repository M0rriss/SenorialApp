import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlClientes } from '@app/core/constants/url-constant';
import { ClienteRequest } from '@app/core/models/dashboard/clientes/cliente-request';
import { ClienteResponse } from '@app/core/models/dashboard/clientes/cliente-response';
import { CrudService } from '@app/shared/services/crud/crud.service';

@Injectable({
  providedIn: 'root'
})
export class ClienteService extends CrudService<ClienteResponse,ClienteRequest> {

  constructor(protected http: HttpClient) {
    super(http,urlClientes.generic);
 }

}
