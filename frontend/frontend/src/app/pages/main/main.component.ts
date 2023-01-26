import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Item} from "../../data/interfaces/item";
import {environment} from "../../../environments/environment";
import {Router} from "@angular/router";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  public title: string = "Main component with request"

  public itemFromApi1: Item = {
    productName: "",
    description: "",
    price: 0,
    manufacturer: ""
  };
  public itemFromApi2: Item = {
    productName: "",
    description: "",
    price: 0,
    manufacturer: ""
  };
  public itemFromApi3: Item = {
    productName: "",
    description: "",
    price: 0,
    manufacturer: ""
  };
  private readonly apiUrl = environment.apiUrl;

  constructor(private readonly httpClient: HttpClient, private readonly router: Router) {
  }

  ngOnInit():void {
    let itemId = "F8A58416-DA3D-4618-055C-08DAFBCC5A1F";

    //GET
    //in route
    this.httpClient.get<Item>(`${this.apiUrl}/item/get-item/${itemId}`).subscribe((data) => {
      console.log("First item from api", data);
      this.itemFromApi1 = data;
    });
    //also with params or headers...

    //POST
    //with form data...
    //with from body
    let newItem = {
      productName: "laptop",
      description: "laptop asus cu procesor intel",
      price: 2000,
      manufacturer: "ASUS"
    }
    // this.httpClient.post(`${this.apiUrl}/item/create-item`, newItem).subscribe((data:any) => {
    //   console.log("Post response from api", data);
    //
    // })

    //PUT
    let itemIdPatch = "F8A58416-DA3D-4618-055C-08DAFBCC5A1F";
    let patchItem = {
      productName: "Tableta",
      description: "Tableta cu diagonala de 11 inch.",
      price: 1000,
      manufacturer: "SAMSUNG"
    }

    this.httpClient.put(`${this.apiUrl}/item/update-item/${itemIdPatch}`, patchItem).subscribe((data:any) => {
      console.log("Put response from api", data);
    })

    //DELETE
    // let deleteId = "A951FAE6-82EC-4E59-45CB-08DAFBD17459"
    // this.httpClient.delete<Item>(`${this.apiUrl}/item/delete-item/${deleteId}`).subscribe();

  }
  navigateTo(){
    this.router.navigate((['/content', 10]))
  }
}
