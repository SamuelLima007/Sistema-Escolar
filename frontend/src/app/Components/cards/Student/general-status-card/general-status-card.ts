import { Component, effect, Input, signal } from '@angular/core';
import { ɵInternalFormsSharedModule } from '@angular/forms';
import { SubjectInterface } from '../../../../Interfaces/subject-interface';
import { SharedModule } from '../../../../shared-module/shared/shared-module';
import { TrendingUp, Calendar, FileText, X } from 'lucide-angular';
import { StudentInterface } from '../../../../Interfaces/student-interface';
import { SubmittedTaskInterface } from '../../../../Interfaces/submittedtask-interface';
import { Taskservice } from '../../../../Services/Tasks/taskservice';
import { MyTaskInterface } from '../../../../Interfaces/mytask-interface';
import { TeacherInterface } from '../../../../Interfaces/teacher-interface';
import { Userservice } from '../../../../Services/Users/userservice';
import { Academicservice } from '../../../../Services/Academic/academicservice';
import { AcademicInterface } from '../../../../Interfaces/academic-interface';

@Component({
  selector: 'app-general-status-card',
  imports: [ɵInternalFormsSharedModule, SharedModule],
  templateUrl: './general-status-card.html',
  styleUrl: './general-status-card.css',
})
export class GeneralStatusCard {

  readonly Calendar = Calendar;
  readonly TrendingUp = TrendingUp;
  readonly FileText = FileText;
  readonly X = X;

  @Input() subjects: SubjectInterface[] = [];
  @Input() submittedtasks: SubmittedTaskInterface[] = [];
  @Input() tasks: MyTaskInterface[] = [];

  Teacher = signal<TeacherInterface>({ name: '', role: '', email: '' });
  academic = signal<AcademicInterface[]>([]);
  academicselected = <AcademicInterface>{ id: 0, year: '0', unit: 0, startdate: '', endDate: '', active: false };

  viewsubmittedtasks: SubmittedTaskInterface[] = [];
  viewnexttests: MyTaskInterface[] = [];
  subjectscore: number = 0;
  stundentstatus = signal<'Aprovado' | 'Reprovado' | 'Em Andamento' | 'Não Iniciada'>('Reprovado');
  SelectedSubject = signal<SubjectInterface>({ id: 0, name: '' });
  Unit = signal<number>(1);

  selectedTest: MyTaskInterface | null = null;

  constructor(
    private _taskservice: Taskservice,
    private _userservice: Userservice,
    private _academicservice: Academicservice,
  ) {
    effect(() => {
      if (this.SelectedSubject() && this.Unit()) {
        this.FilterTaskBySubject();
        this.GetTestsAndFilterBySubjectAndUnit();
        this.GetTeacher();
        this.GetSubjectScore();
      }
    });

    effect(() => {
      if (this.academic().length > 0) this.GetSelectedPeriod();
      this.StudentIsAprovedOrNot();
    });

    effect(() => {
      if (this.academicselected && this.SelectedSubject()) this.StudentIsAprovedOrNot();
    });
  }

  ngOnInit() {
    this.GetPeriods();
  }

  ngOnChanges() {
    if (this.subjects[0]?.id && this.subjects[0]?.name) this.SelectedSubject.set(this.subjects[0]);
  }

  GetSelectedPeriod() {
    this.academicselected = this._academicservice.GetSelectedPeriod(this.academic(), this.Unit());
  }

  StudentIsAprovedOrNot() {
    this.stundentstatus.set(
      this._userservice.StudentIsAprovedOrNot(this.subjectscore, this.academicselected)
    );
  }

  GetPeriods() {
    this._academicservice.GetPeriod().subscribe({
      next: (res) => { if (res != undefined) this.academic.set(res.data); },
      error: (err) => { console.log(err); },
    });
  }

  GetSubjectScore() {
    this.subjectscore = this._userservice.GetStudentSubjectAverageScore(
      this.submittedtasks, this.SelectedSubject().id, this.Unit()
    );
  }

  GetTeacher() {
    this._userservice.GetTeacher(this.SelectedSubject().id, this.tasks[0].classId).subscribe({
      next: (res) => { this.Teacher.set(res.data); },
      error: (err) => { console.log('Erro ao obter dados do usuário:', err); },
    });
  }

  FilterTaskBySubject() {
    this.viewsubmittedtasks = this._taskservice.FilterTaskBySubjectAndUnit(
      this.Unit(), this.SelectedSubject(), this.submittedtasks
    );
  }

  GetTestsAndFilterBySubjectAndUnit() {
    this.viewnexttests = this._taskservice.GetTests(this.tasks);
    this.viewnexttests = this._taskservice.FilterTestBySubjectAndUnit(
      this.Unit(), this.SelectedSubject(), this.viewnexttests
    );
  }

  openModal(test: MyTaskInterface) {
    this.selectedTest = test;
  }

  closeModal() {
    this.selectedTest = null;
  }

  get averageScore(): number {
    if (this.viewsubmittedtasks.length === 0) return 0;
    const total = this.viewsubmittedtasks.reduce((acc, t) => acc + t.score, 0);
    return Math.round((total / this.viewsubmittedtasks.length) * 10) / 10;
  }

  getTaskType(myTaskId: number): string {
    const task = this.tasks.find(t => t.id === myTaskId);
    return task?.type === 'Test' ? 'Prova' : 'Trabalho';
  }

  get statusConfig() {
    const map = {
      'Aprovado':     { css: 'bg-green-600/20 text-green-500 border border-green-500/20' },
      'Reprovado':    { css: 'bg-red-600/20 text-red-500 border border-red-500/20' },
      'Em Andamento': { css: 'bg-yellow-600/20 text-yellow-500 border border-yellow-500/20' },
      'Não Iniciada': { css: 'bg-gray-600/20 text-gray-400 border border-gray-500/20' },
    };
    return map[this.stundentstatus()];
  }

  get studentstatuscolor() {
    const status = this.stundentstatus();
    if (status === 'Não Iniciada') return { css: 'text-white/60', bar: 'bg-gray-400/60' };
    if (this.subjectscore >= 7) return { css: 'text-green-400', bar: 'bg-green-400/60' };
    return { css: 'text-red-400', bar: 'bg-red-400/60' };
  }

}