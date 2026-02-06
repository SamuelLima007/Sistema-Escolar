import { Routes } from '@angular/router';
import { Navbar } from './Components/navbar/navbar';
import { BellIcon } from './Icons/bell-icon/bell-icon';
import { Login } from './Pages/login/login';
import { LogoIcon } from './Icons/logo-icon/logo-icon';
import { authGuard } from './Services/Auth/authguard-guard';
import { Main } from './Pages/main/main/main';

export const routes: Routes = [
  { path: '', component: Login, data: { ShowNavBar: true } },
  { path: 'main', component: Main, canActivate: [authGuard], data: { showNavbar: true } },
];
