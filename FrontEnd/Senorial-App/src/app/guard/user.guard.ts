import { CanActivateFn } from '@angular/router';
import { LoginResponse } from '@app/core/models/login-request';
import { HomePageComponent } from '@app/ecommerce/pages/home-page/home-page.component';


export const userGuard: CanActivateFn = (route, state) => {
  const data = localStorage.getItem('usuario') ?? '';
  if(data == ''){
    alert("No iniciaste session");
    return false;
  }
  else{
    return true;
  }
 
};
