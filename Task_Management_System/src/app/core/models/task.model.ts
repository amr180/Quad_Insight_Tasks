import { TaskStatus } from './enums';

// شكل المستخدم المصغّر جوه الـ Task (من TaskService.MapTask في الباك)
export interface TaskUserSummary {
  id: number;
  name: string;
  email: string;
}

// شكل التاسك زي ما بيرجع من كل الـ endpoints بتاعة TasksController
export interface AppTask {
  id: number;
  title: string;
  description: string | null;
  status: TaskStatus;
  createdAt: string;
  user: TaskUserSummary | null;
}

// بيطابق CreateTaskDto في الباك
export interface CreateTaskRequest {
  title: string;
  description?: string | null;
  userId?: number | null;
}

// بيطابق UpdateTaskDto في الباك
export interface UpdateTaskRequest {
  title: string;
  description?: string | null;
  userId?: number | null;
}

// بيطابق UpdateTaskStatusDto في الباك
export interface UpdateTaskStatusRequest {
  status: TaskStatus;
}

// شكل الرد العام لعمليات الإنشاء/التعديل/الحذف في TasksController
export interface ApiMessageResponse {
  id?: number;
  message: string;
}
