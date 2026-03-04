import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PendingTasksCard } from './pending-tasks-card';

describe('PendingTasksCard', () => {
  let component: PendingTasksCard;
  let fixture: ComponentFixture<PendingTasksCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PendingTasksCard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PendingTasksCard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
