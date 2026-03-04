import { Component, Input, signal } from '@angular/core';
import { SharedModule } from '../../../../shared-module/shared/shared-module';
import { MyTaskInterface } from '../../../../Interfaces/mytask-interface';
import { Calendar, ChevronLeft, ChevronRight, NotebookText } from 'lucide-angular';
import { Taskservice } from '../../../../Services/Tasks/taskservice';
import { SubmittedTaskInterface } from '../../../../Interfaces/submittedtask-interface';
import { Academicservice } from '../../../../Services/Academic/academicservice';
import { AcademicInterface } from '../../../../Interfaces/academic-interface';

@Component({
  selector: 'app-pending-tests-card',
  imports: [SharedModule],
  templateUrl: './pending-tests-card.html',
  styleUrl: './pending-tests-card.css',
})
export class PendingTestsCard {
  readonly Calendar = Calendar;
  readonly ChevronLeft = ChevronLeft;
  readonly ChevronRight = ChevronRight;
    readonly NotebookText = NotebookText;

  @Input() pendingtests: MyTaskInterface[] = [];
  @Input() submittedtests: SubmittedTaskInterface[] = [];

  pendingTests: MyTaskInterface[] = [];
  pendingTestsFiltered: MyTaskInterface[] = [];
  viewpendingTests: MyTaskInterface[] = [];
  CurrentPage = 0;
academic = signal<AcademicInterface[]>([]);

  constructor(private _taskservice: Taskservice, private _academicservice : Academicservice) {}

  ngOnChanges() {
    this.pendingTestsFiltered = this.pendingtests;
    this.VerifyPendingTestOrSubmitted();
   
    this.viewpendingTests = this.pendingTestsFiltered.slice(0, 3);
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


  VerifyPendingTestOrSubmitted() {
    this.pendingTestsFiltered = this._taskservice.GetTests(this.pendingTestsFiltered);
   
    this.pendingTestsFiltered = this._taskservice.VerifyPendingTestOrSubmitted(
      this.pendingTestsFiltered,
      this.submittedtests,
      this.academic()
    );
  }

  Paginator(number: number) {
    var rowperpage = 3;
    var totalpages = Math.ceil(this.pendingTestsFiltered.length / rowperpage);

    this.CurrentPage += number;
    if (this.CurrentPage < 0) this.CurrentPage = 0;
    if (this.CurrentPage >= totalpages) this.CurrentPage = totalpages - 1;

    var start = this.CurrentPage * 3;
    var end = start + 3;
    this.viewpendingTests = this.pendingTestsFiltered.slice(start, end);
  }
}
