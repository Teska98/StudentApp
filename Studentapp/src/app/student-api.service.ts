import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentApiService {

  readonly StudentAPIURl = "https://localhost:44394/api";
  getCourseList: any;

  constructor(private http:HttpClient) { }
 
  //Student

  getStudentList():Observable<any[]>{
    return this.http.get<any>(this.StudentAPIURl + '/Student');
  }

  addStudent(data:any){
    return this.http.post(this.StudentAPIURl + '/Student',data);
  }

  updateStudent(id:number|string, data:any){
    return this.http.put(this.StudentAPIURl + `/Student/${id}`, data);
  }

  deleteStudent(id:number|string){
    return this.http.delete(this.StudentAPIURl + `/Student/${id}`);
  }

  //Course

  addCourseList(data:any){
    return this.http.post(this.StudentAPIURl + '/Course',data);
  }

}
