import { TestBed } from '@angular/core/testing';

import { Academicservice } from './academicservice';

describe('Academicservice', () => {
  let service: Academicservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Academicservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
