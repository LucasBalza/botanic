import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PlantService } from '../../services/plant.service';
import { AuthService } from '../../services/auth.service';
import { Plant, PlantDto } from '../../models/plant';

@Component({
  selector: 'app-plant-detail',
  templateUrl: './plant-detail.component.html',
  styleUrls: ['./plant-detail.component.css']
})
export class PlantDetailComponent implements OnInit {
  plant: Plant | null = null;
  isLoading: boolean = false;
  errorMessage: string = '';
  isEditing: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private plantService: PlantService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadPlant(+id);
    }
  }

  loadPlant(id: number): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.plantService.getPlant(id).subscribe({
      next: (plant) => {
        this.plant = plant;
        this.isLoading = false;
      },
      error: (error) => {
        this.errorMessage = 'Erreur lors du chargement de la plante';
        this.isLoading = false;
      }
    });
  }

  toggleEdit(): void {
    this.isEditing = !this.isEditing;
  }

  savePlant(plantDto: PlantDto): void {
    if (this.plant) {
      this.isLoading = true;
      this.plantService.updatePlant(this.plant.id, plantDto).subscribe({
        next: () => {
          this.loadPlant(this.plant!.id);
          this.isEditing = false;
        },
        error: (error) => {
          this.errorMessage = 'Erreur lors de la sauvegarde';
          this.isLoading = false;
        }
      });
    }
  }

  deletePlant(): void {
    if (this.plant && confirm('Êtes-vous sûr de vouloir supprimer cette plante ?')) {
      this.isLoading = true;
      this.plantService.deletePlant(this.plant.id).subscribe({
        next: () => {
          this.router.navigate(['/plants']);
        },
        error: (error) => {
          this.errorMessage = 'Erreur lors de la suppression';
          this.isLoading = false;
        }
      });
    }
  }

  goBack(): void {
    this.router.navigate(['/plants']);
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }
}
