import { Component } from '@angular/core';

interface PendingTask {
  assigneeInitials: string;
  assigneeName: string;
  title: string;
  description: string;
}

@Component({
  selector: 'app-pending-tasks',
  imports: [],
  templateUrl: './pending-tasks.html',
  styleUrl: './pending-tasks.css'
})
export class PendingTasks {
  readonly tasks: PendingTask[] = [
    {
      assigneeInitials: 'MA',
      assigneeName: 'محمد أحمد',
      title: 'ربط بوابة الدفع الإلكتروني',
      description: 'مطلوب إنهاء اختبارات الأمان والتكامل للخدمات الحالية'
    }
  ];
}
