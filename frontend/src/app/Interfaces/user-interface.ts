import { SubjectInterface } from "./subject-interface";

export interface UserInterface {
  name: string;
  role: string;
  classid: number;
  class: string;
  score1: number;
  score2: number;
  score3: number;
  score4: number;
  subjects: SubjectInterface[];
  
}
