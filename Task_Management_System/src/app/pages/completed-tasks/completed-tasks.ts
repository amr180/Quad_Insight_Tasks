import { Component } from '@angular/core';

interface CompletedTask {
  assigneeInitials: string;
  assigneeName: string;
  title: string;
  subtasks: string[];
}

@Component({
  selector: 'app-completed-tasks',
  imports: [],
  templateUrl: './completed-tasks.html',
  styleUrl: './completed-tasks.css'
})
export class CompletedTasks {
  readonly tasks: CompletedTask[] = [
    {
      assigneeInitials: 'MA',
      assigneeName: 'محمد أحمد',
      title: 'create css pages and html pages',
      subtasks: ['complete structure', 'complete design']
    }
  ];
}
