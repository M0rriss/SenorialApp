import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequest, LoginResponse } from '@app/core/models/login-request';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http:HttpClient
  ) { }
  login(data: LoginRequest){
    return this.http.post<LoginResponse>("https://localhost:7283/api/Auth/LoginDash", data);
  }
}
