import { Component } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ItemService} from "../../core/services/item/item.service";
import {UserService} from "../../core/services/user/user.service";
import {User} from "../../data/interfaces/user";

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {

  public employeesFromApi: User [] = []
  constructor(private readonly userService: UserService) {
  }

  getEmployees() {
    this.userService.getEmployees().subscribe(data => {
      this.employeesFromApi = data;
      console.log(this.employeesFromApi);
    });
  }

  ngOnInit(): void{
    this.getEmployees();
  }
}


