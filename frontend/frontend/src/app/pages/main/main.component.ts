import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Item} from "../../data/interfaces/item";
import {environment} from "../../../environments/environment";
import {Router} from "@angular/router";
import {AuthService} from "../../core/services/auth/auth.service";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  public title: string = "Main component with request"


  private readonly apiUrl = environment.apiUrl;

  constructor(private readonly httpClient: HttpClient,
              private readonly router: Router,
              private readonly authService: AuthService) {
  }

  ngOnInit():void {


  }
  logout(){
      this.authService.logout();
      this.router.navigate(['/main']).then(() => window.location.reload());
  }
  navigateTo(){
    this.router.navigate((['/content']))
  }
}
