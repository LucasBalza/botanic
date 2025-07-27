import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Plant, PlantDto } from '../models/plant';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class PlantService {
  private apiUrl = 'http://localhost:5229/api/Plant';

  constructor(
    private http: HttpClient,
    private authService: AuthService
  ) { }

  private getHeaders(): HttpHeaders {
    const token = this.authService.getToken();
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
  }

  getPlants(): Observable<Plant[]> {
    return this.http.get<Plant[]>(this.apiUrl);
  }

  getPlant(id: number): Observable<Plant> {
    return this.http.get<Plant>(`${this.apiUrl}/${id}`);
  }

  createPlant(plantDto: PlantDto): Observable<Plant> {
    return this.http.post<Plant>(this.apiUrl, plantDto, {
      headers: this.getHeaders()
    });
  }

  updatePlant(id: number, plantDto: PlantDto): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, plantDto, {
      headers: this.getHeaders()
    });
  }

  deletePlant(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`, {
      headers: this.getHeaders()
    });
  }
}
