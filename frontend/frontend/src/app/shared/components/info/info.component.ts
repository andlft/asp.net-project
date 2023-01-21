import {Component, OnInit} from '@angular/core';
import {Item} from "../../../data/interfaces/item";
import {ItemService} from "../../../core/services/item/item.service";

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})
export class InfoComponent implements OnInit{
  public itemFromApi: Item = {productName: "", description: "", price: 0, manufacturer: ""};

  constructor(private readonly itemService: ItemService) {
  }

  ngOnInit(): void {
    let itemId = "F8A58416-DA3D-4618-055C-08DAFBCC5A1F";
    this.itemService.getItemWithQueryParams(itemId).subscribe(data => {
      console.log('getItemWithQueryParams', data);
      this.itemFromApi = data;
    });

    this.itemService.getItemWithQueryParamsFilter(itemId).subscribe(data => {
      this.itemFromApi = data;
    });

    this.itemService.response.subscribe((data: any) => {
      console.log("response from BehaviorSubject", data);
      this.itemFromApi = data;
    });

  }

}
