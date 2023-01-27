import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


//Components
import {InfoComponent} from "./info/info.component";
import {MatCardModule} from "@angular/material/card";
let componentsArray = [InfoComponent]



@NgModule({
  declarations: componentsArray,
  exports: componentsArray,
  imports: [
    CommonModule,
    MatCardModule
  ]
})
export class ComponentsModule { }
