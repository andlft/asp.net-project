import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit{
  public dataPassedInRoute = 0;
  constructor(private readonly route: ActivatedRoute) {

  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      console.log(params);
      this.dataPassedInRoute = +params['id'];
    })
  }

}
