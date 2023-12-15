import { Injectable } from '@angular/core';
import { ApiService } from "./api.service";
import { Course } from "../models/course";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class CourseService extends ApiService<Course> {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public override getPath(): string {
    return 'courses';
  }
}
