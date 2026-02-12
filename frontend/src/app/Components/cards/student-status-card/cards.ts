import { Component, Input } from '@angular/core';
import { SharedModule } from 'primeng/api';

@Component({
  selector: 'app-student-status-card',
  imports: [SharedModule],
  templateUrl: './cards.html',
  styleUrl: './cards.css',
})
export class Cards {
  @Input() SubjectCount = 0;

}
