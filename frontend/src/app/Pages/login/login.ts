import { Component } from '@angular/core';
import { SharedModule } from '../../shared-module/shared/shared-module';
import { LogoIcon } from '../../Icons/logo-icon/logo-icon';
import { GraduationCap } from 'lucide-angular/src/icons';

@Component({
  selector: 'app-login',
  imports: [SharedModule, LogoIcon],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  readonly GraduationCap = GraduationCap;
}
