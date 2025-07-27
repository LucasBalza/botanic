import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PlantService } from '../../services/plant.service';
import { AuthService } from '../../services/auth.service';
import { Plant } from '../../models/plant';

@Component({
  selector: 'app-plant-list',
  templateUrl: './plant-list.component.html',
  styleUrls: ['./plant-list.component.css']
})
export class PlantListComponent implements OnInit {
  plants: Plant[] = [];
  isLoading: boolean = false;
  errorMessage: string = '';

  constructor(
    private plantService: PlantService,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadPlants();
  }

  loadPlants(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.plantService.getPlants().subscribe({
      next: (plants) => {
        this.plants = plants;
        this.isLoading = false;
      },
      error: (error) => {
        this.errorMessage = 'Erreur lors du chargement des plantes';
        this.isLoading = false;
      }
    });
  }

  viewPlant(id: number): void {
    this.router.navigate(['/plants', id]);
  }

  addPlant(): void {
    this.router.navigate(['/plants/add']);
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }
}
