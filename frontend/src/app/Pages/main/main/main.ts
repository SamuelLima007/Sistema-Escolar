import { Component, signal, Signal } from '@angular/core';
import { Navbar } from '../../../Components/navbar/navbar';
import { Cards } from '../../../Components/cards/student-status-card/cards';
import { Userservice } from '../../../Services/Users/userservice';
import { UserInterface } from '../../../Interfaces/user-interface';
import { SharedModule } from '../../../shared-module/shared/shared-module';
import { PendingTasksCard } from "../../../Components/cards/pending-tasks-card/pending-tasks-card";
import { UpcomingTestsCard } from "../../../Components/cards/upcoming-tests-card/upcoming-tests-card";

@Component({
  selector: 'app-main',
  imports: [Navbar, Cards, SharedModule, PendingTasksCard, UpcomingTestsCard],
  templateUrl: './main.html',
  styleUrl: './main.css',
})
export class Main {
  constructor(private _userservice: Userservice) {}

  ngOnInit(): void {
    this.GetUserLogged();
  }

  User = signal<UserInterface>({
    name: '',
    role: '',
    classid: 0,
    class: '',
    score1: 0,
    score2: 0,
    score3: 0,
    score4: 0,
  });

  GetUserLogged() {
    this._userservice.GetUserLogged().subscribe({
      next: (res) => {
        console.log('Sucesso ao obter dados do usuário:', res.data);
        this.User.set(res.data);

        console.log(this.User().name, this.User().role);
        return this.User;
        
      },
      error: (err) => {
        console.log('Erro ao obter dados do usuário:', err);
      },
    });
  }
}
