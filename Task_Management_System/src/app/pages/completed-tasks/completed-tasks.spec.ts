import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CompletedTasks } from './completed-tasks';

describe('CompletedTasks', () => {
  let component: CompletedTasks;
  let fixture: ComponentFixture<CompletedTasks>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompletedTasks],
    }).compileComponents();

    fixture = TestBed.createComponent(CompletedTasks);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
