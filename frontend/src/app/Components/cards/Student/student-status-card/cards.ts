import { Component, effect, Input, signal } from '@angular/core';

import { FormsModule } from "@angular/forms";
import { StudentInterface } from '../../../../Interfaces/student-interface';
import { Taskservice } from '../../../../Services/Tasks/taskservice';
import { Userservice } from '../../../../Services/Users/userservice';
import { MyTaskInterface } from '../../../../Interfaces/mytask-interface';
import { Academicservice } from '../../../../Services/Academic/academicservice';
import { AcademicInterface } from '../../../../Interfaces/academic-interface';
import { year } from '@primeuix/themes/aura/datepicker';
import { SharedModule } from '../../../../shared-module/shared/shared-module';

@Component({
  selector: 'app-student-status-card',
  imports: [SharedModule],
  templateUrl: './cards.html',
  styleUrl: './cards.css',
})
export class Cards {
  constructor(
    private _taskservice: Taskservice,
    private _userservice: Userservice,
     private _academicservice: Academicservice,
   
  ) {effect(() =>{if (this.Unit()) this.GetGeneralAverageScore()})}

  @Input() student!: StudentInterface;

  Tasks: MyTaskInterface[] = []

  SubjectCount = 0;
  TasksCount = 0;
  TestsCount = 0;
  GeneralAverage = 0;
  Unit = signal<number>(1)
 academic = signal<AcademicInterface[]>([]);


 ngOnInit()
{
  this.GetPeriods()
}

  ngOnChanges() {
    this.GetSubjects();
    this.GetTasks();
    this.GetTests();
    this.GetGeneralAverageScore();
  } 

  
  GetPeriods() {
    this._academicservice.GetPeriod().subscribe({
      next: (res) => {
        if (res != undefined) this.academic.set(res.data);
        console.log(this.academic())
       
      },
      error: (err) => {
        console.log(err);
      },
    });
  }


    
  GetGeneralAverageScore()
  {
    this.GeneralAverage = this._userservice.GetStudentGeneralAverageScore(this.student.submittedTasks, this.student.class.subjects, this.Unit())
  }

  GetSubjects() {
    this.SubjectCount = this.student.class.subjects.length;
  }

  GetTasks() {
  
    this.Tasks = this._taskservice.GetTasks(this.student.class.myTasks);
   
    this.TasksCount = this._taskservice.VerifyPendingTestOrSubmitted(this.Tasks, this.student.submittedTasks, this.academic()).length
  
  }

  GetTests() {
  this.TestsCount = this._taskservice.GetTests(this.student.class.myTasks).length;
  }

}
