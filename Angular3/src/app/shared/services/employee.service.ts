import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  host:string='https://localhost:7179';

  constructor(private http:HttpClient) {

   }

   getAllCandidate(){
    return this.http.get(this.host + '/api/Candidate/GetAllCandidate')
   }

   CreateCandidate(candidateModel:any){
    return this.http.post(this.host + '/api/Candidate/CreateCandidate', candidateModel);
   }

   deleteCandidateById(id: number){
    return this.http.delete(this.host + '/api/Candidate/DeleteCandidateById/' + id);
   }
}
