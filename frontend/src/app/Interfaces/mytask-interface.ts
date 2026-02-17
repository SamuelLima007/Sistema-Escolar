export interface MyTaskInterface {
  id: number;
  name: string;
  description: string;
  unit: number;
  score: number;
  creationDate?: string;   
  expirationDate?: string;
  subjectName: string;
  subjectId: number;
  classId: number;
  teacherId: number;
}
