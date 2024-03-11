import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class UserDataService {

  module: string = '/api/users';

  constructor(private http: HttpClient) { }

  get() {
    return this.http.get(this.module);
  }

  post(data: any) {
    return this.http.post(this.module, data);
  }

  put(data: any) {
    return this.http.put(this.module, data);
  }

  delete(data: any) {
    return this.http.delete(this.module + '/' + data);
  }

  authenticate(data: any) {
    return this.http.post(this.module + '/authenticate', data);
  }

}
