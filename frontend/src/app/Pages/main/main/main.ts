import { Component, signal, Signal } from '@angular/core';
import { Navbar } from '../../../Components/navbar/navbar';
import { Cards } from '../../../Components/cards/cards';
import { Userservice } from '../../../Services/Users/userservice';
import { UserInterface } from '../../../Interfaces/user-interface';

@Component({
  selector: 'app-main',
  imports: [Navbar, Cards],
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

        console.log(this.User().name);
        return this.User;
      },
      error: (err) => {
        console.log('Erro ao obter dados do usuário:', err);
      },
    });
  }
}
