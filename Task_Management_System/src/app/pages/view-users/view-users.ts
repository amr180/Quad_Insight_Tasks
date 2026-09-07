import { DOCUMENT } from '@angular/common';
import { Component, HostListener, inject } from '@angular/core';

interface AppUser {
  name: string;
  email: string;
  tasksCount: string;
  status: string;
}

interface UserTask {
  title: string;
  description: string;
  status: 'pending' | 'completed';
}

@Component({
  selector: 'app-view-users',
  imports: [],
  templateUrl: './view-users.html',
  styleUrl: './view-users.css'
})
export class ViewUsers {
  private readonly document = inject(DOCUMENT);

  readonly users: AppUser[] = [
    { name: 'أحمد محمود', email: 'ahmed@quadinsight.com', tasksCount: '4 مهام', status: 'نشط' }
  ];
  private readonly demoTasks: UserTask[] = [
    { title: 'Fix Login Bug', description: 'Fix authentication issue.', status: 'pending' },
    { title: 'Create Dashboard', description: 'Build dashboard UI.', status: 'completed' }
  ];

  isTasksModalOpen = false;
  modalUserName = '';
  modalUserEmail = '';
  modalTasks: UserTask[] = [];

  get modalUserInitials(): string {
    return this.modalUserName
      .split(' ')
      .map(part => part.charAt(0))
      .join('')
      .toUpperCase();
  }

  openUserModal(name: string, email: string): void {
    this.modalUserName = name;
    this.modalUserEmail = email;
    this.modalTasks = this.demoTasks;
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
