import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlProveedores } from '@app/core/constants/url-constant';
import { ProveedorRequest } from '@app/core/models/dashboard/proveedores/proveedor.request';
import { ProveedorResponse } from '@app/core/models/dashboard/proveedores/proveedor.response';
import { CrudService } from '@app/shared/services/crud/crud.service';

@Injectable({
  providedIn: 'root'
})
export class ProveedorService extends CrudService<ProveedorResponse,ProveedorRequest>{

  constructor(protected http: HttpClient) {
    super(http,urlProveedores.generic);
  }

}
