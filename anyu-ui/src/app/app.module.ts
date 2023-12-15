import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthComponent } from './components/auth/auth.component';
import { HttpClientModule } from "@angular/common/http";
import { CourseListComponent } from './components/course-list/course-list.component';
import { CourseComponent } from './components/course/course.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from "@angular/material/toolbar";
import { NgOptimizedImage } from "@angular/common";

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent,
    AuthComponent,
    CourseComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    CourseListComponent,
    NgOptimizedImage
  ],
  providers: []
})
export class AppModule {
}
