import { ClassInterface } from "./class-interface";
import { SubjectInterface } from "./subject-interface";
import { SubmittedTaskInterface } from "./submittedtask-interface";

export interface StudentInterface {
  name: string;
  role: string;
  class: ClassInterface;
  score1: number;
  score2: number;
  score3: number;
  score4: number;
  submittedTasks: SubmittedTaskInterface[]
}
