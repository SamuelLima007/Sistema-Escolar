import { Component, computed, signal, Signal } from '@angular/core';
import { Navbar } from '../../../Components/navbar/navbar';
import { Cards } from '../../../Components/cards/Student/student-status-card/cards';
import { Userservice } from '../../../Services/Users/userservice';
import { StudentInterface } from '../../../Interfaces/student-interface';
import { SharedModule } from '../../../shared-module/shared/shared-module';
import { PendingTasksCard } from '../../../Components/cards/Student/pending-tasks-card/pending-tasks-card';

import { GeneralStatusCard } from '../../../Components/cards/Student/general-status-card/general-status-card';
import { PendingTestsCard } from '../../../Components/cards/Student/pending-tests-card/pending-tests-card';

@Component({
  selector: 'app-main',
  imports: [
    Navbar,
    Cards,
    SharedModule,
    PendingTasksCard,
    GeneralStatusCard,
    PendingTestsCard,
  ],
  templateUrl: './main.html',
  styleUrl: './main.css',
})
export class Main {
  constructor(private _userservice: Userservice) {}

  

  
  ngOnInit(): void {
    this.GetUserLogged();
  }

  User = signal<StudentInterface>({
    name: '',
    role: '',
    class: {
      id: 0,
      grade: '',
      subjects: [],
      myTasks: [],
    },
    score1: 0,
    score2: 0,
    score3: 0,
    score4: 0,
    submittedTasks: [],
  });
 


  GetUserLogged() {
    this._userservice.GetUserLogged().subscribe({
      next: (res) => {
        console.log(res);
        this.User.set(res.data);
      },
      error: (err) => {
        console.log('Erro ao obter dados do usuário:', err);
      },
    });
  }

}
