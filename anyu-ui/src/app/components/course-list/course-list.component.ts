import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { CourseService } from "../../services/course.service";
import { Course } from "../../models/course";
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { MatProgressBarModule } from "@angular/material/progress-bar";
import { NgIf } from "@angular/common";

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss'],
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule, MatProgressBarModule, NgIf, RouterLink],
})
export class CourseListComponent implements OnInit, AfterViewInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public courses: Course[] | undefined;
  public displayedColumns: string[] = ['name', 'code', 'category', 'credit', 'description'];
  public dataSource = new MatTableDataSource<Course>();
  public pageSizeOptions = [5, 10, 25];
  public hidePageSize = false;
  public showPageSizeOptions = true;
  public showFirstLastButtons = true;
  public pageEvent: PageEvent = {
    pageIndex: 0,
    pageSize: 10,
    length: 0
  };

  constructor(private courseService: CourseService) {
  }

  ngAfterViewInit() {
  }

  async ngOnInit(): Promise<void> {
    await this.getCourses();
  }

  async getCourses(): Promise<void> {
    try {
      const coursesResponse = await this.courseService.getPagedList('', this.pageEvent.pageIndex + 1, this.pageEvent.pageSize);
      this.courses = coursesResponse?.value;
      this.dataSource = new MatTableDataSource<Course>(this.courses);
      this.pageEvent = {
        pageIndex: (coursesResponse?.currentPage ?? 1) - 1,
        pageSize: Math.max(coursesResponse?.currentPageResults ?? this.pageEvent.pageSize, this.pageEvent.pageSize) ?? 10,
        length: coursesResponse?.totalResults ?? 0
      };
    } catch (e) {
      console.log(e);
    }
  }

  handlePageEvent(event: PageEvent) {
    if (this.pageEvent.pageSize != event.pageSize) {
      event.pageIndex = 0;
    }
    this.pageEvent = event;
    this.getCourses();
  }
}
