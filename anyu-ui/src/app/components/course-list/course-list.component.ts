import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { CourseService } from "../../services/course.service";
import { Course } from "../../models/course";
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss'],
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule],
})
export class CourseListComponent implements OnInit, AfterViewInit {
  public courses: Course[] | undefined;
  public displayedColumns: string[] = ['name', 'code', 'category', 'credit', 'description'];
  public dataSource = new MatTableDataSource<Course>();
  @ViewChild(MatPaginator) paginator: MatPaginator;

  public length = 50;
  public pageSize = 10;
  public pageIndex = 0;
  public pageSizeOptions = [5, 10, 25];
  public hidePageSize = false;
  public showPageSizeOptions = true;
  public showFirstLastButtons = true;
  public disabled = false;
  public pageEvent: PageEvent;

  constructor(private courseService: CourseService) {
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  async ngOnInit(): Promise<void> {
    await this.getCourses();
  }

  async getCourses(): Promise<void> {
    try {
      const coursesResponse = await this.courseService.getPagedList('', this.pageIndex + 1, this.pageSize);
      this.courses = coursesResponse?.value;
      this.dataSource = new MatTableDataSource<Course>(this.courses);
    } catch (e) {
      console.log(e);
    }
  }

  handlePageEvent(e: PageEvent) {
    this.pageEvent = e;
    this.length = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
    this.getCourses();
  }

  setPageSizeOptions(setPageSizeOptionsInput: string) {
    if (setPageSizeOptionsInput) {
      this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => +str);
    }
  }
}
