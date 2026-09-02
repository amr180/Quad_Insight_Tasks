import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PendingTasks } from './pending-tasks';

describe('PendingTasks', () => {
  let component: PendingTasks;
  let fixture: ComponentFixture<PendingTasks>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PendingTasks],
    }).compileComponents();

    fixture = TestBed.createComponent(PendingTasks);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
