import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LucideAngularModule } from 'lucide-angular';
import { MessageModule } from 'primeng/message'
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [],
  imports: [CommonModule],
  exports: [CommonModule, LucideAngularModule, MessageModule, ReactiveFormsModule, RouterModule],
})
export class SharedModule {}
