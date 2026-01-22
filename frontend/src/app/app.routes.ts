import { Routes } from '@angular/router';
import { Navbar } from './Components/navbar/navbar';
import { BellIcon } from './Icons/bell-icon/bell-icon';
import { Login } from './Pages/login/login';
import { LogoIcon } from './Icons/logo-icon/logo-icon';

export const routes: Routes = [

    {path: '', component:Login}
];
