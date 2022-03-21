import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { StudentApiService } from 'src/app/student-api.service';

@Component({
  selector: 'app-show-student',
  templateUrl: './show-student.component.html',
  styleUrls: ['./show-student.component.css']
})
export class ShowStudentComponent implements OnInit {

  studentList$!:Observable<any[]>
  courseList$!:Observable<any[]>;
  courseList:any=[];
  

  //Map to display data associate with foreign key
  courseListMap:Map<number, string> = new Map()

  constructor(private service:StudentApiService) { }

  ngOnInit(): void {
    this.studentList$ = this.service.getStudentList();
    this.courseList$ = this.service.getCourseList();
    this.refreshcourseListMap();
  }

  refreshcourseListMap() {
    this.service.getCourseList().subscribe((data: string | any[]) => {
      this.courseList = data;

      for(let i = 0; i < data.length; i++)
      {
        this.courseListMap.set(this.courseList[i].id, this.courseList[i].courseName);
      }
    })
  }

}

