import { Component } from '@angular/core';
import { NavBarComponent } from '../../Components/nav-bar/nav-bar.component';

@Component({
  selector: 'app-login',
  imports: [NavBarComponent],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'], // Corrigido de styleUrl para styleUrls
})
export class LoginComponent {}
