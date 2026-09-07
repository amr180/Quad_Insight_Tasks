import { CommonModule, DOCUMENT } from '@angular/common';
import { Component, HostListener, OnInit, inject } from '@angular/core';
import { UserService } from '../../core/services/user.service';
import { AppUser, UserTaskSummary } from '../../core/models/user.model';
import { TaskStatus } from '../../core/models/enums';

@Component({
  selector: 'app-view-users',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './view-users.html',
  styleUrl: './view-users.css'
})
export class ViewUsers implements OnInit {
  private readonly document = inject(DOCUMENT);
  private readonly userService = inject(UserService);

  readonly TaskStatus = TaskStatus;

  users: AppUser[] = [];
  isLoading = true;
  errorMessage = '';

  isTasksModalOpen = false;
  modalUserName = '';
  modalUserEmail = '';
  modalTasks: UserTaskSummary[] = [];

  ngOnInit(): void {
    this.loadUsers();
  }

  private loadUsers(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.userService.getAll().subscribe({
      next: (users) => {
        this.users = users;
        this.isLoading = false;
      },
      error: () => {
        this.errorMessage = 'تعذر تحميل المستخدمين من السيرفر.';
        this.isLoading = false;
      }
    });
  }

  get modalUserInitials(): string {
    return this.modalUserName
      .split(' ')
      .filter(Boolean)
      .map((part) => part.charAt(0))
      .join('')
      .toUpperCase();
  }

  openUserModal(user: AppUser): void {
    this.modalUserName = user.name;
    this.modalUserEmail = user.email;
    this.modalTasks = user.tasks;
    this.isTasksModalOpen = true;
    this.document.body.style.overflow = 'hidden';
  }

  closeUserModal(): void {
    this.isTasksModalOpen = false;
    this.document.body.style.overflow = '';
  }

  onOverlayClick(event: MouseEvent): void {
    if (event.target === event.currentTarget) {
      this.closeUserModal();
    }
  }

  @HostListener('document:keydown.escape')
  onEscape(): void {
    if (this.isTasksModalOpen) {
      this.closeUserModal();
    }
  }
}
