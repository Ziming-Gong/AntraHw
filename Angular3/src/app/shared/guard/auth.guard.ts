import { CanActivateFn } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  if(localStorage.hasOwnProperty("authenticationToken")){
    return true;
  }
  return false;
};
