import { HttpInterceptorFn } from '@angular/common/http';
import { LoginResponse } from '@app/core/models/login-request';

export const AuthInterceptor: HttpInterceptorFn = (req, next) => {
  let json = sessionStorage.getItem('user') ?? '';
  if(json == ''){
    return next(req);
  }
  let user = JSON.parse(json) as LoginResponse;
  const token = user.token;
  const modreq = req.clone({
    
    setHeaders: {
      authorization: `Bearer ${token}`
    }
  });

  return next(modreq);
};
