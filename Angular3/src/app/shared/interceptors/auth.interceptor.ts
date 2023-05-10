import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { AuthenticationService } from '../services/authentication.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private auth:AuthenticationService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    // check the token is validable
    const token = this.auth.getToken();
    if(token){
      request=request.clone({
        setHeaders:{'authorization' :'Bearer ' + token}
      });
    }


    return next.handle(request);
  }
}
