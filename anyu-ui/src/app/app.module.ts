import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthComponent } from './components/auth/auth.component';
import { HttpClientModule } from "@angular/common/http";
import { CourseListComponent } from './components/course-list/course-list.component';
import { CourseComponent } from './components/course/course.component';

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent,
    AuthComponent,
    CourseListComponent,
    CourseComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule
  ],
  providers: []
})
export class AppModule {
}
