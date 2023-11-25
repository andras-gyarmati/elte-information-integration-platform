import { Injectable } from '@angular/core';
import { ApiService } from "./api.service";
import { User } from "../models/user";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService extends ApiService<User> {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public override getPath(): string {
    return 'users';
  }
}
