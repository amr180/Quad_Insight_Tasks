import { DOCUMENT } from '@angular/common';
import { Component, HostListener, inject } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class DashboardComponent {
  private readonly document = inject(DOCUMENT);

  isTaskModalOpen = false;

  openTaskModal(): void {
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
  onAddUserSubmit(form: HTMLFormElement, event: Event): void {
    event.preventDefault();
    form.reset();
  }
}
