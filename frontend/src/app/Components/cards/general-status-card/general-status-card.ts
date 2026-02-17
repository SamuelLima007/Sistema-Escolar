import { Component, Input,  signal } from '@angular/core';
import { ɵInternalFormsSharedModule } from "@angular/forms";
import { SubjectInterface } from '../../../Interfaces/subject-interface';
import { SharedModule } from '../../../shared-module/shared/shared-module';
import { TrendingUp } from 'lucide-angular';
import { StudentInterface } from '../../../Interfaces/student-interface';
import { ClassInterface } from '../../../Interfaces/class-interface';
import { Subject } from 'rxjs';
import { SubmittedTaskInterface } from '../../../Interfaces/submittedtask-interface';

@Component({
  selector: 'app-general-status-card',
  imports: [ɵInternalFormsSharedModule, SharedModule],
  templateUrl: './general-status-card.html',
  styleUrl: './general-status-card.css',
})
export class GeneralStatusCard {

  readonly TrendingUp = TrendingUp;


  ngOnChanges()
  {
      this.SelectedSubject.set(this.subjects[0].name)

  }


 @Input() subjects : SubjectInterface[] = []
  @Input() submittedtasks : SubmittedTaskInterface[] = []

  SelectedSubject = signal<string>('')


  




}
