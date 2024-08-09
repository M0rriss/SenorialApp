import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlAuth } from '@app/core/constants/url-constant';
import { LoginRequest, LoginResponse } from '@app/core/models/login-request';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StaffPersonalService {

  constructor(protected http:HttpClient) { }

  loginDashboard(req: LoginRequest) : Observable<LoginResponse>{
    var res = this.http.post<LoginResponse>(urlAuth.loginDash,req);
    return res;
  }
  
}
