import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MainComponent} from "./pages/main/main.component";
import {InfoComponent} from "./shared/components/info/info.component";
import {ContentComponent} from "./pages/content/content.component";

const routes: Routes = [
  {
    path: "main",
    component: MainComponent
  },
  {
    path: "content/:id",
    component: ContentComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
