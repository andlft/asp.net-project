import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ItemService} from "../../core/services/item/item.service";
import {Item} from "../../data/interfaces/item";

@Component({
  selector: 'app-item-content',
  templateUrl: './item-content.component.html',
  styleUrls: ['./item-content.component.css']
})
export class ItemContentComponent implements OnInit{
  public itemFromApi: Item = {productName: "", description: "", price: 0, manufacturer: "",id: ""};
  public dataPassedInRoute = "";
  constructor(private readonly route: ActivatedRoute, private readonly itemService: ItemService) {

  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      console.log(params);
      this.dataPassedInRoute = params['id'];
    });

    this.itemService.getItemWithQueryParams(this.dataPassedInRoute).subscribe(data => {
      this.itemFromApi = data;
    })

  }
}
