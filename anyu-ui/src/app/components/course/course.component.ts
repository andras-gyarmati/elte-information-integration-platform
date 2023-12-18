import { Component } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { CourseService } from "../../services/course.service";
import { Course } from "../../models/course";

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent {
  private courseCode: number;
  public course: Course | undefined;
  public errorMessage: string | undefined;

  constructor(private route: ActivatedRoute, private courseService: CourseService) {
    this.route.params.subscribe(params => {
      this.courseCode = params['code'];
      this.getCourse().then(() => {
      });
    });
  }

  points = [20, 40, 60, 80, 100];

  async getCourse() {
    try {
      const courseResponse = await this.courseService.get(this.courseCode);
      this.course = courseResponse?.value;
    } catch (e: any) {
      console.log(e);
      this.errorMessage = e?.error?.errorMessage ?? e?.error?.message ?? e?.message ?? e?.error ?? e;
    }
  }
}
