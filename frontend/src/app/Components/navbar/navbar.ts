import { Component, Input, signal } from '@angular/core';
import { LogoIcon } from "../../Icons/logo-icon/logo-icon";
import { BellIcon } from "../../Icons/bell-icon/bell-icon";
import { LogoutIcon } from '../../Icons/logout-icon/logout-icon';
import { SharedModule } from '../../shared-module/shared/shared-module';



@Component({
  selector: 'app-navbar',
  imports: [SharedModule,LogoIcon, LogoIcon, BellIcon, LogoutIcon],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class Navbar {

Notification = signal(false);
UserRoleMessage = '';

NotificationPop(Notification : boolean)
{
    this.Notification.set(Notification)
}

}
