import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PendingTestsCard } from './pending-tests-card';

describe('PendingTestsCard', () => {
  let component: PendingTestsCard;
  let fixture: ComponentFixture<PendingTestsCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PendingTestsCard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PendingTestsCard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
