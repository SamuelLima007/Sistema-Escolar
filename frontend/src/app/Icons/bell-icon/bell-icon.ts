import { Component } from '@angular/core';
import { Bell } from 'lucide-angular';
import { SharedModule } from '../../shared-module/shared/shared-module';

@Component({
  selector: 'app-bell-icon',
  imports: [SharedModule],
  templateUrl: './bell-icon.html',
  styleUrl: './bell-icon.css',
})
export class BellIcon {
    readonly Bell = Bell
}
