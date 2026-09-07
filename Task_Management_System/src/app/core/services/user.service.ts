import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import {
  ApiMessageResponse,
  AppUser,
  CreateUserRequest,
  UpdateUserRequest
} from '../models/user.model';

@Injectable({ providedIn: 'root' })
export class UserService {
  private readonly baseUrl = `${environment.apiUrl}/users`;

  constructor(private readonly http: HttpClient) {}

  // GET /api/users
  getAll(): Observable<AppUser[]> {
    return this.http.get<AppUser[]>(this.baseUrl);
  }

  // GET /api/users/{id}
  getById(id: number): Observable<AppUser> {
    return this.http.get<AppUser>(`${this.baseUrl}/${id}`);
  }

  // POST /api/users
  create(user: CreateUserRequest): Observable<ApiMessageResponse> {
    return this.http.post<ApiMessageResponse>(this.baseUrl, user);
  }

  // PUT /api/users/{id}
  update(id: number, user: UpdateUserRequest): Observable<ApiMessageResponse> {
    return this.http.put<ApiMessageResponse>(`${this.baseUrl}/${id}`, user);
  }

  // DELETE /api/users/{id}
  delete(id: number): Observable<ApiMessageResponse> {
    return this.http.delete<ApiMessageResponse>(`${this.baseUrl}/${id}`);
  }
}
