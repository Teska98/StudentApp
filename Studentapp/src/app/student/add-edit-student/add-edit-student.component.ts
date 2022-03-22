import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { StudentApiService } from 'src/app/student-api.service';

@Component({
  selector: 'app-add-edit-student',
  templateUrl: './add-edit-student.component.html',
  styleUrls: ['./add-edit-student.component.css']
})
export class AddEditInspectionComponent implements OnInit {

  inspectionList$!: Observable<any[]>;
  statusList$!: Observable<any[]>;
  inspectionTypesList$!: Observable<any[]>;

  constructor(private service:StudentApiService) { }

  @Input() inspection:any;
  id: number = 0;
  ime: string = "";
  prezime: string = "";
  brojindexa!: number;
  studentStatusId!: number;

  ngOnInit(): void {
    this.id = this.student.id;
    this.ime = this.inspection.status;
    this.prezime = this.inspection.comments;
    this.statusStudentaId = this.inspection.inspectionTypeId;
    this.statusList$ = this.service.getStatusList();
    this.inspectionList$ = this.service.getInspectionList();
    this.inspectionTypesList$ = this.service.getInspectionTypesList();
  }

  addInspection() {
    var inspection = {
      status:this.status,
      comments:this.comments,
      inspectionTypeId:this.inspectionTypeId
    }
    this.service.addInspection(inspection).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn) {
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById('add-success-alert');
      if(showAddSuccess) {
        showAddSuccess.style.display = "block";
      }
      setTimeout(function() {
        if(showAddSuccess) {
          showAddSuccess.style.display = "none"
        }
      }, 4000);
    })
  }

  updateInspection() {
    var inspection = {
      id: this.id,
      status:this.status,
      comments:this.comments,
      inspectionTypeId:this.inspectionTypeId
    }
    var id:number = this.id;
    this.service.updateInspection(id,inspection).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn) {
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-success-alert');
      if(showUpdateSuccess) {
        showUpdateSuccess.style.display = "block";
      }
      setTimeout(function() {
        if(showUpdateSuccess) {
          showUpdateSuccess.style.display = "none"
        }
      }, 4000);
    })

  }

}