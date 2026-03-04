import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralStatusCard } from './general-status-card';

describe('GeneralStatusCard', () => {
  let component: GeneralStatusCard;
  let fixture: ComponentFixture<GeneralStatusCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GeneralStatusCard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GeneralStatusCard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
