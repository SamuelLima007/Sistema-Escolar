import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { MyTaskInterface } from '../../Interfaces/mytask-interface';
import { SubmittedTaskInterface } from '../../Interfaces/submittedtask-interface';
import { SubjectInterface } from '../../Interfaces/subject-interface';
import { AcademicInterface } from '../../Interfaces/academic-interface';

@Injectable({
  providedIn: 'root',
})
export class Taskservice {
  constructor(
    private http: HttpClient,
    private router: Router,
  ) {}

  GetTests(taskList: MyTaskInterface[]) {
    return taskList.filter((x) => x.type == 'Test');
  }

  FilterTaskBySubjectAndUnit(
    unit: number,
    subject: SubjectInterface,
    submittedTasks: SubmittedTaskInterface[],
  ) {
    return submittedTasks.filter((x) => x.subjectId == subject.id && x.unit == unit);
  }

  FilterTestBySubjectAndUnit(unit: number, subject: SubjectInterface, Tests: MyTaskInterface[]) {
    return Tests.filter((x) => x.subjectId == subject.id && x.unit == unit);
  }

  GetTasks(taskList: MyTaskInterface[]) {
    return taskList.filter((x) => x.type == 'Task');
  }

  VerifyPendingTestOrSubmitted( taskList: MyTaskInterface[], submittedtasklist: SubmittedTaskInterface[], academic : AcademicInterface[] ) 
  {
    const period = academic.find(x => x.active)
    if(period != undefined)  return taskList.filter((task) => !submittedtasklist.some((x) => x.myTaskId === task.id && task.unit === period.unit));
   

    return taskList.filter((task) => !submittedtasklist.some((x) => x.myTaskId === task.id));

  
  }
}
