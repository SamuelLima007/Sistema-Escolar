import { MyTaskInterface } from "./mytask-interface";
import { SubjectInterface } from "./subject-interface";

export interface ClassInterface {
  id: number;
  grade: string;
  subjects: SubjectInterface[];
   myTasks: MyTaskInterface[];
 
}

