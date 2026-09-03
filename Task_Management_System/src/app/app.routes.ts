import { Routes } from '@angular/router';
import { Dashboard} from './pages/dashboard/dashboard';
import { ViewUsers } from './pages/view-users/view-users';
import { CompletedTasks } from './pages/completed-tasks/completed-tasks';
import { PendingTasks } from './pages/pending-tasks/pending-tasks';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'users', component: ViewUsers },
  { path: 'completed-tasks', component: CompletedTasks },
  { path: 'pending-tasks', component: PendingTasks },
  { path: '**', redirectTo: 'dashboard' }
];