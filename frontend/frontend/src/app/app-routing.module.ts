import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MainComponent} from "./pages/main/main.component";
import {InfoComponent} from "./shared/components/info/info.component";
import {ContentComponent} from "./pages/content/content.component";
import {ItemContentComponent} from "./pages/item-content/item-content.component";
import {LoginComponent} from "./pages/login/login.component";
import {AdminModule} from "./pages/admin/admin.module";
import {AuthGuard} from "./core/guards/auth.guard";

const routes: Routes = [
  {
    path: "main",
    canActivate: [AuthGuard],
    component: MainComponent
  },
  {
    path: "content/:id",
    canActivate: [AuthGuard],
    component: ItemContentComponent
  },
  {
    path: "content",
    canActivate: [AuthGuard],
    component: ContentComponent
  },
  {
    path: "login",
    component: LoginComponent
  },
  {
    path: "admin",
    canActivate: [AuthGuard],
    loadChildren: () => import('./pages/admin/admin.module').then(m => AdminModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
