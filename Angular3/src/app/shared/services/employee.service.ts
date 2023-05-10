import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http:HttpClient) {

   }

   getAll(){
    return this.http.get('https://localhost:7179/api/Candidate/GetAllCandidate')
   }
}
