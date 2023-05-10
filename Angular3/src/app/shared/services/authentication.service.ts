import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private httpClient:HttpClient) { 

  }



  login(username:any, password:any){
    let UserCredential = {
      username:username,
      password:password
    }
    return this.httpClient.post('http://localhost:40121/api/Account/SignIn', UserCredential);
  }

  getToken(){
    if(localStorage.hasOwnProperty("authenticationToken")){
      return localStorage.getItem('authenticationToken');
    }
    return null;
  }
}
