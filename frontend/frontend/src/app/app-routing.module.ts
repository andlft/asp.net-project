import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MainComponent} from "./pages/main/main.component";
import {InfoComponent} from "./shared/components/info/info.component";
import {ContentComponent} from "./pages/content/content.component";
import {ItemContentComponent} from "./pages/item-content/item-content.component";
import {RegisterComponent} from "./register/register.component";
import {AdminModule} from "./pages/admin/admin.module";

const routes: Routes = [
  {
    path: "main",
    component: MainComponent
  },
  {
    path: "content/:id",
    component: ItemContentComponent
  },
  {
    path: "content",
    component: ContentComponent
  },
  {
    path: "register",
    component: RegisterComponent
  },
  {
    path: "admin",
    loadChildren: () => import('./pages/admin/admin.module').then(m => AdminModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
