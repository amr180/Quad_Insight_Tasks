import { Component, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { Sidebar } from '../../components/sidebar/sidebar';
@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule, Sidebar],
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.css']
})
export class Dashboard {
  isModalOpen = false;

  user = { name: '', email: '' };
  task = { title: '', description: '', dueDate: '' };

  @HostListener('document:keydown.escape')
  onEscape() {
    this.isModalOpen = false;
  }

  closeModalOnOverlay(event: MouseEvent) {
    if ((event.target as HTMLElement).classList.contains('modal-overlay')) {
      this.isModalOpen = false;
    }
  }

  onSaveUser() {
    console.log('User saved:', this.user);
  }

  onAddTask() {
    console.log('Task added:', this.task);
    this.isModalOpen = false;
  }
}