import { Routes } from '@angular/router';
export const routes: Routes = [
  {
    path: '',redirectTo: 'dashboard',pathMatch: 'full'},
  {
    path: 'dashboard',title: 'TaskManagement System',
    loadComponent: () =>import('./pages/dashboard/dashboard').then(m => m.Dashboard)
  },
  {
    path: 'users',title: 'TaskManagement | عرض كافة المستخدمين',
    loadComponent: () =>import('./pages/view-users/view-users').then(m => m.ViewUsers)
  },
  {
    path: 'tasks/completed',title: 'المهام المكتملة',
    loadComponent: () =>
      import('./pages/completed-tasks/completed-tasks').then(m => m.CompletedTasks)
  },
  {
    path: 'tasks/pending', title: 'المهام قيد الانتظار',
    loadComponent: () =>import('./pages/pending-tasks/pending-tasks').then(m => m.PendingTasks)
  },
  
  {
    path: '**',
    title: '404 — الصفحة غير موجودة',
    loadComponent: () =>import('./pages/not-found/not-found').then(m => m.NotFoundComponent)
  }
];
