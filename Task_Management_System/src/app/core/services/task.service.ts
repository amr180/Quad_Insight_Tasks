import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import {
  ApiMessageResponse,
  AppTask,
  CreateTaskRequest,
  UpdateTaskRequest,
  UpdateTaskStatusRequest
} from '../models/task.model';

@Injectable({ providedIn: 'root' })
export class TaskService {
  private readonly baseUrl = `${environment.apiUrl}/tasks`;

  constructor(private readonly http: HttpClient) {}

  // GET /api/tasks
  getAll(): Observable<AppTask[]> {
    return this.http.get<AppTask[]>(this.baseUrl);
  }

  // GET /api/tasks/{id}
  getById(id: number): Observable<AppTask> {
    return this.http.get<AppTask>(`${this.baseUrl}/${id}`);
  }

  // POST /api/tasks
  create(task: CreateTaskRequest): Observable<ApiMessageResponse> {
    return this.http.post<ApiMessageResponse>(this.baseUrl, task);
  }

  // PUT /api/tasks/{id}
  update(id: number, task: UpdateTaskRequest): Observable<ApiMessageResponse> {
    return this.http.put<ApiMessageResponse>(`${this.baseUrl}/${id}`, task);
  }

  // DELETE /api/tasks/{id}
  delete(id: number): Observable<ApiMessageResponse> {
    return this.http.delete<ApiMessageResponse>(`${this.baseUrl}/${id}`);
  }

  // PATCH /api/tasks/{id}/status
  updateStatus(id: number, status: UpdateTaskStatusRequest): Observable<ApiMessageResponse> {
    return this.http.patch<ApiMessageResponse>(`${this.baseUrl}/${id}/status`, status);
  }

  // GET /api/tasks/user/{userId}
  getByUserId(userId: number): Observable<AppTask[]> {
    return this.http.get<AppTask[]>(`${this.baseUrl}/user/${userId}`);
  }
}
