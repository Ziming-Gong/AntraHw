import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VendorService {

  constructor(private http:HttpClient) { }

  host:string='https://localhost:7179';
  getAllVendor(){
    return this.http.get(this.host + '/GetAllJobRequirement');
  }
}
