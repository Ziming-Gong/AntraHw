import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { EmployeeAddComponent } from "./employee-add/employee-add.component";
import { EmployeeListComponent } from "./employee-list/employee-list.component";

const routes:Routes=[
    {path:'add', component:EmployeeAddComponent},
    {path:'list', component:EmployeeListComponent}
]


@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule]
})
export class EmployeeRoutingModule{

}