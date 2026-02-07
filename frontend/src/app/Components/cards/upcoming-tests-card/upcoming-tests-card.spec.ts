import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpcomingTestsCard } from './upcoming-tests-card';

describe('UpcomingTestsCard', () => {
  let component: UpcomingTestsCard;
  let fixture: ComponentFixture<UpcomingTestsCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpcomingTestsCard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpcomingTestsCard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
