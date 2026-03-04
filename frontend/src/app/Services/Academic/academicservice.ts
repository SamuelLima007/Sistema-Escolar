import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AcademicInterface } from '../../Interfaces/academic-interface';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Academicservice {
  private ApiUrl = 'http://localhost:5110/periods';

  constructor(private http: HttpClient) {}

  periods: AcademicInterface[] = [];

  GetActivePeriod() {
    return this.http.get<any>(this.ApiUrl).pipe(
      map((list) => {
       
        const activeperiod : AcademicInterface = list.data.find((x: AcademicInterface) => x.active === true);
       
        return activeperiod
        
      }),
    );
  }

  GetPeriod() {
    return this.http.get<any>(this.ApiUrl)
  }

   GetSelectedPeriod(periods : AcademicInterface[], unit: number) {
  
    
    var a = periods.find(x => x.unit == unit)

    if (a != undefined) return a
    return <AcademicInterface> ({id: 1, year: "0", unit: 0, startdate: "", endDate: "", active:false  })
  }
}
