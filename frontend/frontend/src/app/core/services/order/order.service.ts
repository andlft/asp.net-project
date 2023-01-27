import { Injectable } from '@angular/core';
import {BehaviorSubject, map} from "rxjs";
import {ApiService} from "../api/api.service";

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private readonly route = "/order";
  private responseSource = new BehaviorSubject<object>({});
  public response = this.responseSource.asObservable();

  constructor(private readonly apiService: ApiService) { }

  getOrderWithQueryParams(Id = "") {
    return this.apiService.get(this.route + '/get-item/' + Id);
  }

  getOrderWithQueryParamsFilter(Id = "") {
    return this.apiService.get(this.route + '/get-item/' + Id).pipe(map(x => {
      console.log("data from api inside service", x);
      this.responseSource.next(x);
      return x;
    }));
  }
  getAll() {
    return this.apiService.get(this.route+'/getallitems');
  }
}
