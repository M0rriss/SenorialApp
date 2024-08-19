import { CanActivateFn } from '@angular/router';
import { LoginResponse } from '@app/core/models/login-request';


export const authGuard: CanActivateFn = (route, state) => {
  const data = sessionStorage.getItem('user') ?? '';
  if(data == ''){
    alert("No tienes perimiso");
    return false;
  }
  else{
    return true;
  }
 
};

