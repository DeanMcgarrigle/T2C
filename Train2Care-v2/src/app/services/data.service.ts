import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import "rxjs/add/observable/throw";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/map";

@Injectable()
export class DataService {
  private server = environment.apiUrl;

  constructor(private http: HttpClient) {}

  test() {
    return this.http.get(this.server + "/api/test").map(res => res, err => err);
  }
}
