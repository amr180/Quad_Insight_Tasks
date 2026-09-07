import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { TaskService } from '../../core/services/task.service';
import { AppTask } from '../../core/models/task.model';
import { TaskStatus } from '../../core/models/enums';

@Component({
  selector: 'app-completed-tasks',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './completed-tasks.html',
  styleUrl: './completed-tasks.css'
})
export class CompletedTasks implements OnInit {
  private readonly taskService = inject(TaskService);

  tasks: AppTask[] = [];
  isLoading = true;
  errorMessage = '';

  ngOnInit(): void {
    this.taskService.getAll().subscribe({
      next: (tasks) => {
        this.tasks = tasks.filter((task) => task.status === TaskStatus.Completed);
        this.isLoading = false;
      },
      error: () => {
        this.errorMessage = 'تعذر تحميل المهام المكتملة.';
        this.isLoading = false;
      }
    });
  }

  assigneeInitials(task: AppTask): string {
    if (!task.user) {
      return '—';
    }

    return task.user.name
      .split(' ')
      .filter(Boolean)
      .map((part) => part.charAt(0))
      .join('')
      .toUpperCase();
  }
}
