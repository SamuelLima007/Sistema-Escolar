import { Component, Input, signal } from '@angular/core';
import { SharedModule } from '../../../../shared-module/shared/shared-module';
import { ChevronLeft, ChevronRight, NotebookText } from 'lucide-angular';
import { MyTaskInterface } from '../../../../Interfaces/mytask-interface';
import { SubmittedTaskInterface } from '../../../../Interfaces/submittedtask-interface';
import { Taskservice } from '../../../../Services/Tasks/taskservice';
import { Academicservice } from '../../../../Services/Academic/academicservice';
import { AcademicInterface } from '../../../../Interfaces/academic-interface';

@Component({
  selector: 'app-pending-tasks-card',
  imports: [SharedModule],
  templateUrl: './pending-tasks-card.html',
  styleUrl: './pending-tasks-card.css',
})
export class PendingTasksCard {

readonly NotebookText = NotebookText
readonly ChevronLeft = ChevronLeft
readonly ChevronRight = ChevronRight

@Input() pendingtasks : MyTaskInterface[] = []
@Input() submittedtasks : SubmittedTaskInterface[] = []

pendingtasksfiltered : MyTaskInterface[] = []
viewpendingtasks : MyTaskInterface[] = [];
CurrentPage = 0;
academic = signal<AcademicInterface[]>([]);

constructor(private _taskservice : Taskservice, private _academicservice : Academicservice){}

ngOnInit()
{
  this.GetPeriods()
}

ngOnChanges()
{
  this.pendingtasksfiltered = this.pendingtasks
  this.VerifyPendingTestOrSubmitted()

  this.viewpendingtasks = this.pendingtasksfiltered.slice(0, 3)
 
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

VerifyPendingTestOrSubmitted()
{
  this.pendingtasksfiltered = this._taskservice.GetTasks(this.pendingtasksfiltered)

  this.pendingtasksfiltered = this._taskservice.VerifyPendingTestOrSubmitted(this.pendingtasksfiltered, this.submittedtasks, this.academic())
}

Paginator(number: number)
{
  var rowperpage = 3;
  var totalpages = Math.ceil(this.pendingtasksfiltered.length / rowperpage); 
  

  this.CurrentPage += number;
  if (this.CurrentPage < 0 ) this.CurrentPage = 0
  if (this.CurrentPage >= totalpages ) this.CurrentPage = totalpages - 1
  
  
  var start = this.CurrentPage * 3
  var end = start + 3
  this.viewpendingtasks = this.pendingtasksfiltered.slice(start, end)


}







}
