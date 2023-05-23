import { Component } from '@angular/core';
import { VendorService } from 'src/app/shared/services/vendor.service';

@Component({
  selector: 'app-vendor-list',
  templateUrl: './vendor-list.component.html',
  styleUrls: ['./vendor-list.component.css']
})
export class VendorListComponent {
  constructor(private service:VendorService){
    this.service.getAllVendor().subscribe(jobs => {
      console.log(jobs);
      this.jobList = jobs;
    });
  }

  jobList:any;
  getAllJob(){
    this.service.getAllVendor().subscribe(jobs => {
      this.jobList = jobs;
    });

  }

}
