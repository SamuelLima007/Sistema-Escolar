import { Component, inject } from '@angular/core';
import { SharedModule } from '../../shared-module/shared/shared-module';
import { LogoIcon } from '../../Icons/logo-icon/logo-icon';
import { GraduationCap } from 'lucide-angular/src/icons';
import { Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [SharedModule, LogoIcon],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  private formBuilder = inject(FormBuilder);

  loginForm = this.formBuilder.group({
    email: [
      '',
      Validators.required,
      Validators.pattern(
        '^[a-zA-Z0-9.!#$%&&#39;*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?)*$',
      ),
    ],
    password: ['', Validators.required, Validators.minLength(12) ],
  });
  readonly GraduationCap = GraduationCap;


  onSubmit()
  {
    if (this.loginForm.valid)
    {

    }
    
   
  }
}
