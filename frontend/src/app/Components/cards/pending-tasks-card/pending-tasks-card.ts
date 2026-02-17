import { Component, Input } from '@angular/core';
import { SharedModule } from '../../../shared-module/shared/shared-module';
import { ChevronLeft, ChevronRight, NotebookText } from 'lucide-angular';
import { MyTaskInterface } from '../../../Interfaces/mytask-interface';
import { SubmittedTaskInterface } from '../../../Interfaces/submittedtask-interface';

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

viewpendingtasks : MyTaskInterface[] = [];
CurrentPage = 0;

ngOnChanges()
{
  this.viewpendingtasks = this.pendingtasks.slice(0, 3)
 
}

Paginator(number: number)
{
  var rowperpage = 3;
  var totalpages = Math.ceil(this.pendingtasks.length / rowperpage); 
  

  this.CurrentPage += number;
  if (this.CurrentPage < 0 ) this.CurrentPage = 0
  if (this.CurrentPage >= totalpages ) this.CurrentPage = totalpages - 1
  
  
  var start = this.CurrentPage * 3
  var end = start + 3
  this.viewpendingtasks = this.pendingtasks.slice(start, end)


}







}
