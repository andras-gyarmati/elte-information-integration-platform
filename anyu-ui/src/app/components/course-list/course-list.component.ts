import { Component, OnInit } from '@angular/core';
import { CourseService } from "../../services/course.service";
import { Course } from "../../models/course";

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.sass']
})
export class CourseListComponent implements OnInit {
  private courses: Course[] | undefined;

  constructor(private courseService: CourseService) {
  }

  async ngOnInit(): Promise<void> {
    await this.getCourses();
  }

  async getCourses(): Promise<void> {
    try {
      const coursesResponse = await this.courseService.getPagedList('', 1, 10);
      this.courses = coursesResponse?.value;
    } catch (e) {
      console.log(e);
    }
  }
}
