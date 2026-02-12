import { Component, Input, signal } from '@angular/core';
import { ɵInternalFormsSharedModule } from "@angular/forms";
import { SubjectInterface } from '../../../Interfaces/subject-interface';
import { SharedModule } from '../../../shared-module/shared/shared-module';

@Component({
  selector: 'app-general-status-card',
  imports: [ɵInternalFormsSharedModule, SharedModule],
  templateUrl: './general-status-card.html',
  styleUrl: './general-status-card.css',
})
export class GeneralStatusCard {
 @Input() subjects: SubjectInterface[] = [];

 
 valorSelecionado = signal<string>("teste");


  ngOnInit(): void
  {
   
   
    console.log(this.subjects)
     console.log("teste");
  }

  ngOnChanges() {
     this.valorSelecionado.set(this.subjects[0].name)
  console.log('Recebi subjects:', this.subjects);
}

  

   

  

}
