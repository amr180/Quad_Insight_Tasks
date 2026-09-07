import { TaskStatus } from './enums';

// المهمة المختصرة اللي بترجع جوه المستخدم (من UserService.MapTask المصغّر في الباك)
export interface UserTaskSummary {
  id: number;
  title: string;
  description: string | null;
  status: TaskStatus;
  createdAt: string;
}

// شكل المستخدم زي ما بيرجع من GET /api/users و GET /api/users/{id}
export interface AppUser {
  id: number;
  name: string;
  email: string;
  tasks: UserTaskSummary[];
}

// بيطابق CreateUserDto في الباك
export interface CreateUserRequest {
  name: string;
  email: string;
}

// بيطابق UpdateUserDto في الباك
export interface UpdateUserRequest {
  name: string;
  email: string;
}

// شكل الرد العام لعمليات الإنشاء/التعديل/الحذف في UsersController
export interface ApiMessageResponse {
  id?: number;
  message: string;
}
