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
  studentStatusMap:Map<number, string> = new Map()

  constructor(private service:StudentApiService) { }

  ngOnInit(): void {
    this.studentList$ = this.service.getStudentList();
    this.courseList$ = this.service.getCourseList();
    this.refreshstudentStatusMap();
  }

  modalTitle:string = '';
  activateAddEditStudentComponent:boolean = false;
  student:any;

  modalAdd() {
    this.student = {
      id:0,
      ime:null,
      prezime:null,
      brojindexa:null,
      godinaStudija:null,
      statusStudentaId:null
    }
    this.modalTitle = "Add Student";
    this.activateAddEditStudentComponent = true;
  }


  refreshstudentStatusMap() {
    this.service.getCourseList().subscribe((data: string | any[]) => {
      this.studentList = data;

      for(let i = 0; i < data.length; i++)
      {
        this.studentStatusMap.set(this.studentList[i].id, this.studentList[i].studentName);
      }
    })
  }

}

