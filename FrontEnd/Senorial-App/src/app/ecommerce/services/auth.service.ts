import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlAuth } from '@app/core/constants/url-constant';
import { LoginRecuperarRequest } from '@app/core/models/ecommerce/components/staff-personal/login-recuperar-request';
import { LoginRegisterRequest } from '@app/core/models/ecommerce/components/staff-personal/login-register-request';
import { LoginVerificarRequest } from '@app/core/models/ecommerce/components/staff-personal/login-verificar-request';
import { CustomResponse } from '@app/core/models/generic/custom-response';
import { LoginRequest, LoginResponse } from '@app/core/models/login-request';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http:HttpClient
  ) { }
  login(data: LoginRequest) : Observable<LoginResponse>{
    return this.http.post<LoginResponse>(urlAuth.loginEcommerce, data);
  }
  //ECOMMERCE
  Registro(req: LoginRegisterRequest) : Observable<LoginResponse>{
    var res = this.http.post<LoginResponse>(urlAuth.registerEcommerce, req);
    return res;
  }

  recuperar(req: LoginRecuperarRequest) : Observable<CustomResponse>{
    var res = this.http.post<CustomResponse>(urlAuth.recuperEcommerce, req);
    return res;
  }

  verificar(req: LoginVerificarRequest) : Observable<CustomResponse>{
    var res = this.http.put<CustomResponse>(urlAuth.verificarEcommerce, req);
    return res;
  }
}
