import { Injectable } from '@angular/core';
import {ApiService} from "../api/api.service";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly route = '/user';

  constructor(private readonly apiService: ApiService) { }

  getEmployees() {
    return this.apiService.get(this.route + '/GetEmployees');
  }
}
