import { Component } from '@angular/core';
import { GraduationCap } from 'lucide-angular'
import { SharedModule } from '../../shared-module/shared/shared-module';

@Component({
  selector: 'app-logo-icon',
  imports: [SharedModule],
  templateUrl: './logo-icon.html',
  styleUrl: './logo-icon.css',
})
export class LogoIcon {
 readonly GraduationCap = GraduationCap
}
