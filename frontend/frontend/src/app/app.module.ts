import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbar, MatToolbarModule} from "@angular/material/toolbar";
import {MatCardModule} from "@angular/material/card";

import {MainComponent} from "./pages/main/main.component";
import {ContentComponent} from "./pages/content/content.component";
import {InfoComponent} from "./shared/components/info/info.component";
import {HttpClientModule} from "@angular/common/http";
import { ItemContentComponent } from './pages/item-content/item-content.component';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    ContentComponent,
    InfoComponent,
    ItemContentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatCardModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
