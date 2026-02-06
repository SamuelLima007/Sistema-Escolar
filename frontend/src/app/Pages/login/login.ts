import { Component, inject, signal } from '@angular/core';
import { SharedModule } from '../../shared-module/shared/shared-module';
import { LogoIcon } from '../../Icons/logo-icon/logo-icon';
import { GraduationCap } from 'lucide-angular/src/icons';
import { Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Authservice } from '../../Services/Auth/authservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [SharedModule, LogoIcon],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  private _formBuilder = inject(FormBuilder);
  private _authService = inject(Authservice);

  constructor(private _router: Router) {}

  loginForm = this._formBuilder.group({
    email: ['', [Validators.required]],
    password: ['', [Validators.required]],
  });
  readonly GraduationCap = GraduationCap;
  ErrorLogin = signal(false);
  ErrorMessage = signal('');

  UpdateLoginErrorState(state: boolean) {
    this.ErrorLogin.update(() => state);
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.ErrorMessage.set('');
      this._authService

        .Login(this.loginForm.value.email!, this.loginForm.value.password!)
        .subscribe({
          next: (res) => {
            this._authService.Savetoken(res.token);
            this._router.navigate(['/main']);
          },

          error: (err) => {
            this.UpdateLoginErrorState(true);
          },
        });
    } else {
      this.UpdateLoginErrorState(false);
      this.ErrorMessage.set('Preencha todos os campos corretamente.');
    }
  }
}
