import { CommonModule, DOCUMENT } from '@angular/common';
import { Component, HostListener, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../core/services/user.service';
import { TaskService } from '../../core/services/task.service';
import { AppUser } from '../../core/models/user.model';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard implements OnInit {
  private readonly document = inject(DOCUMENT);
  private readonly userService = inject(UserService);
  private readonly taskService = inject(TaskService);

  // مستخدمين حقيقيين من الباك بنستخدمهم في قايمة "Assign To"
  users: AppUser[] = [];

  isTaskModalOpen = false;

  // فورم إضافة مستخدم
  newUser = { name: '', email: '' };
  isSavingUser = false;
  userErrorMessage = '';
  userSuccessMessage = '';

  // فورم إضافة مهمة
  newTask: { title: string; description: string; userId: number | null } = {
    title: '',
    description: '',
    userId: null
  };
  isSavingTask = false;
  taskErrorMessage = '';

  ngOnInit(): void {
    this.loadUsers();
  }

  private loadUsers(): void {
    this.userService.getAll().subscribe({
      next: (users) => (this.users = users),
      error: () => (this.users = [])
    });
  }

  onAddUserSubmit(form: HTMLFormElement, event: Event): void {
    event.preventDefault();
    this.userErrorMessage = '';
    this.userSuccessMessage = '';

    if (!this.newUser.name.trim() || !this.newUser.email.trim()) {
      this.userErrorMessage = 'من فضلك أدخل الاسم والبريد الإلكتروني.';
      return;
    }

    this.isSavingUser = true;

    this.userService.create(this.newUser).subscribe({
      next: () => {
        this.isSavingUser = false;
        this.userSuccessMessage = 'تم إضافة المستخدم بنجاح.';
        this.newUser = { name: '', email: '' };
        form.reset();
        this.loadUsers();
      },
      error: (err) => {
        this.isSavingUser = false;
        this.userErrorMessage = err?.error?.message ?? 'حدث خطأ أثناء إضافة المستخدم.';
      }
    });
  }

  openTaskModal(): void {
    this.taskErrorMessage = '';
    this.newTask = { title: '', description: '', userId: null };
    this.isTaskModalOpen = true;
    this.document.body.style.overflow = 'hidden';
  }

  closeTaskModal(): void {
    this.isTaskModalOpen = false;
    this.document.body.style.overflow = '';
  }

  onOverlayClick(event: MouseEvent): void {
    if (event.target === event.currentTarget) {
      this.closeTaskModal();
    }
  }

  @HostListener('document:keydown.escape')
  onEscape(): void {
    if (this.isTaskModalOpen) {
      this.closeTaskModal();
    }
  }

  onAddTaskSubmit(): void {
    this.taskErrorMessage = '';

    if (!this.newTask.title.trim() || !this.newTask.description.trim()) {
      this.taskErrorMessage = 'من فضلك أدخل اسم المهمة والوصف.';
      return;
    }

    this.isSavingTask = true;

    this.taskService
      .create({
        title: this.newTask.title,
        description: this.newTask.description,
        userId: this.newTask.userId
      })
      .subscribe({
        next: () => {
          this.isSavingTask = false;
          this.closeTaskModal();
        },
        error: (err) => {
          this.isSavingTask = false;
          this.taskErrorMessage = err?.error?.message ?? 'حدث خطأ أثناء إضافة المهمة.';
        }
      });
  }
}
