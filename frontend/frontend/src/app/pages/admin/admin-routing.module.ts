import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AdminComponent} from "./admin.component";
import {RouterModule, Routes} from "@angular/router";
import {AdminPageComponent} from "./admin-page/admin-page.component";
import {AdminComponentComponent} from "./admin-component/admin-component.component";

const routes: Routes = [{
  path: "", component: AdminComponent,
  children: [{
    path: "component",
    component: AdminComponentComponent
  }]
},
  {
    path: "home",
    component: AdminPageComponent
  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild((routes))
  ],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
