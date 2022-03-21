import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { StudentComponent } from './student/student.component';
import { ShowStudentComponent } from './student/show-student/show-student.component';
import { AddEditStudentComponent } from './student/add-edit-student/add-edit-student.component';
import { StudentApiService } from './student-api.service';

@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    ShowStudentComponent,
    AddEditStudentComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [StudentApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
