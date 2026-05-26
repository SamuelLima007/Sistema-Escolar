import { Component, Input, signal } from '@angular/core';
import { SharedModule } from '../../../../shared-module/shared/shared-module';
import { ChevronLeft, ChevronRight, NotebookText, X } from 'lucide-angular';
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

  readonly NotebookText = NotebookText;
  readonly ChevronLeft = ChevronLeft;
  readonly ChevronRight = ChevronRight;
  readonly X = X;

  @Input() pendingtasks: MyTaskInterface[] = [];
  @Input() submittedtasks: SubmittedTaskInterface[] = [];

  pendingtasksfiltered: MyTaskInterface[] = [];
  viewpendingtasks: MyTaskInterface[] = [];
  CurrentPage = 0;
  academic = signal<AcademicInterface[]>([]);

  selectedTask: MyTaskInterface | null = null;
  selectedTaskIndex: number = 0;

  private readonly ROWS_PER_PAGE = 3;

  constructor(private _taskservice: Taskservice, private _academicservice: Academicservice) {}

  ngOnInit() {
    this.GetPeriods();
  }

  ngOnChanges() {
    this.CurrentPage = 0;
    this.pendingtasksfiltered = this.pendingtasks;
    this.VerifyPendingTestOrSubmitted();
    this.updateView();
  }

  GetPeriods() {
    this._academicservice.GetPeriod().subscribe({
      next: (res) => {
        if (res != undefined) this.academic.set(res.data);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  VerifyPendingTestOrSubmitted() {
    this.pendingtasksfiltered = this._taskservice.GetTasks(this.pendingtasksfiltered);
    this.pendingtasksfiltered = this._taskservice.VerifyPendingTestOrSubmitted(
      this.pendingtasksfiltered,
      this.submittedtasks,
      this.academic()
    );
  }

  Paginator(number: number) {
    const total = this.getTotalPages();
    this.CurrentPage += number;
    if (this.CurrentPage < 0) this.CurrentPage = 0;
    if (this.CurrentPage >= total) this.CurrentPage = total - 1;
    this.updateView();
  }

  private updateView() {
    const start = this.CurrentPage * this.ROWS_PER_PAGE;
    const end = start + this.ROWS_PER_PAGE;
    this.viewpendingtasks = this.pendingtasksfiltered.slice(start, end);
  }

  getTotalPages(): number {
    return Math.ceil(this.pendingtasksfiltered.length / this.ROWS_PER_PAGE) || 1;
  }

  getTotalPagesArray(): number[] {
    return Array.from({ length: this.getTotalPages() });
  }

  openModal(task: MyTaskInterface, index: number) {
    this.selectedTask = task;
    this.selectedTaskIndex = index;
  }

  closeModal() {
    this.selectedTask = null;
  }

}