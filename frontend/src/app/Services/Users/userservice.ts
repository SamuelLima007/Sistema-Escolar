import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { StudentInterface } from '../../Interfaces/student-interface';
import { SubmittedTaskInterface } from '../../Interfaces/submittedtask-interface';
import { SubjectInterface } from '../../Interfaces/subject-interface';
import { AcademicInterface } from '../../Interfaces/academic-interface';

@Injectable({
  providedIn: 'root',
})
export class Userservice {
  private ApiUrl = 'http://localhost:5110';

  constructor(
    private http: HttpClient,
    private router: Router,
  ) {}

  GetUserLogged() {
    return this.http.get<any>(`${this.ApiUrl}/users/student`);
  }

  GetStudentGeneralAverageScore(
    submittedtasks: SubmittedTaskInterface[],
    subjects: SubjectInterface[],
    unit: Number,
  ) {
    var S_A_Score = 0;
    for (let submittedtask of submittedtasks) {
      if (submittedtask.unit == unit) S_A_Score += submittedtask.score;
    }

    var S_A_Score = S_A_Score / subjects.length;
    return (S_A_Score = Math.round(S_A_Score * 10) / 10);
  }

  StudentIsAprovedOrNot(
    averageScore: number,
    academic: AcademicInterface,
  ): 'Aprovado' | 'Reprovado' | 'Em Andamento' | 'Não Iniciada' {
    const endDate = new Date(academic.endDate);
    const now = Date.now();

    if (academic.active) {
      return 'Em Andamento';
    }

    if (!academic.active && endDate.getTime() < now) {
      return averageScore >= 7 ? 'Aprovado' : 'Reprovado';
    }

    return 'Não Iniciada';
  }

  GetStudentSubjectAverageScore(
    submittedtasks: SubmittedTaskInterface[],
    subjectId: number,
    unit: Number,
  ) {
    var S_A_Score = 0;
    for (let submittedtask of submittedtasks) {
      if (submittedtask.subjectId == subjectId && submittedtask.unit == unit)
        S_A_Score += submittedtask.score;
    }
    var S_A_Score = Math.round(S_A_Score * 10) / 10;
    return S_A_Score;
  }

  GetTeacher(subjectId: Number, classId: Number) {
    return this.http.get<any>(`${this.ApiUrl}/users/teacher/${subjectId}/${classId}`);
  }
}
