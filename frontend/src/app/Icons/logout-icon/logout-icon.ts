import { Component } from '@angular/core';
import { SharedModule } from '../../shared-module/shared/shared-module';
import { LogOut } from 'lucide-angular';

@Component({
  selector: 'app-logout-icon',
  imports: [SharedModule],
  templateUrl: './logout-icon.html',
  styleUrl: './logout-icon.css',
})
export class LogoutIcon {
  readonly LogOut = LogOut

}
