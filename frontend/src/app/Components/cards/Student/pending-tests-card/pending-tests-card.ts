import { Component, Input, signal } from '@angular/core';
import { SharedModule } from '../../../../shared-module/shared/shared-module';
import { MyTaskInterface } from '../../../../Interfaces/mytask-interface';
import { Calendar, ChevronLeft, ChevronRight, X } from 'lucide-angular';
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
  readonly X = X;

  @Input() pendingtests: MyTaskInterface[] = [];
  @Input() submittedtests: SubmittedTaskInterface[] = [];

  pendingTestsFiltered: MyTaskInterface[] = [];
  viewpendingTests: MyTaskInterface[] = [];
  CurrentPage = 0;
  academic = signal<AcademicInterface[]>([]);

  selectedTest: MyTaskInterface | null = null;
  selectedTestIndex: number = 0;

  private readonly ROWS_PER_PAGE = 3;

  constructor(private _taskservice: Taskservice, private _academicservice: Academicservice) {}

  ngOnInit() {
    this.GetPeriods();
  }

  ngOnChanges() {
    this.CurrentPage = 0;
    this.pendingTestsFiltered = this.pendingtests;
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
    this.pendingTestsFiltered = this._taskservice.GetTests(this.pendingTestsFiltered);
    this.pendingTestsFiltered = this._taskservice.VerifyPendingTestOrSubmitted(
      this.pendingTestsFiltered,
      this.submittedtests,
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
    this.viewpendingTests = this.pendingTestsFiltered.slice(start, end);
  }

  getTotalPages(): number {
    return Math.ceil(this.pendingTestsFiltered.length / this.ROWS_PER_PAGE) || 1;
  }

  getTotalPagesArray(): number[] {
    return Array.from({ length: this.getTotalPages() });
  }

  openModal(test: MyTaskInterface, index: number) {
    this.selectedTest = test;
    this.selectedTestIndex = index;
  }

  closeModal() {
    this.selectedTest = null;
  }

}