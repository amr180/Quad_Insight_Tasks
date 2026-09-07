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
  successMessage = '';

  // بنخزن id المهمة اللي بيتم تحديثها دلوقتي عشان نعطل زرارها بس هي ونمنع دوس مزدوج
  updatingTaskId: number | null = null;

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

  // بترجع التاسك من Completed إلى Pending، وبتشيلها من الليستة الحالية بعد النجاح
  returnToPending(task: AppTask): void {
    if (this.updatingTaskId !== null) {
      return;
    }

    this.errorMessage = '';
    this.successMessage = '';
    this.updatingTaskId = task.id;

    this.taskService.updateStatus(task.id, { status: TaskStatus.Pending }).subscribe({
      next: () => {
        this.tasks = this.tasks.filter((t) => t.id !== task.id);
        this.successMessage = `تم إرجاع مهمة "${task.title}" إلى قائمة المهام قيد الانتظار.`;
        this.updatingTaskId = null;

        // اخفاء الرسالة تلقائياً بعد شوية
        setTimeout(() => (this.successMessage = ''), 4000);
      },
      error: () => {
        this.errorMessage = 'تعذر تحديث حالة المهمة، حاول مرة أخرى.';
        this.updatingTaskId = null;
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
