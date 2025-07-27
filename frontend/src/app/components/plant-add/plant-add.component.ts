import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PlantService } from '../../services/plant.service';
import { AuthService } from '../../services/auth.service';
import { PlantDto } from '../../models/plant';

@Component({
  selector: 'app-plant-add',
  templateUrl: './plant-add.component.html',
  styleUrls: ['./plant-add.component.css']
})
export class PlantAddComponent implements OnInit {
  plantForm: FormGroup;
  isLoading: boolean = false;
  errorMessage: string = '';
  successMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private plantService: PlantService,
    private authService: AuthService,
    private router: Router
  ) {
    this.plantForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      description: ['', [Validators.minLength(5)]], // Rendu optionnel mais avec minLength si rempli
      imageUrl: [''],
      scientificName: [''], // Rendu optionnel
      family: [''], // Rendu optionnel
      genus: [''],
      species: [''],
      commonName: [''],
      careInstructions: [''],
      isIndoor: [false],
      isOutdoor: [false],
      isPerennial: [false],
      isAnnual: [false]
    });
  }

  ngOnInit(): void {
    // Vérifier si l'utilisateur est connecté
    if (!this.authService.isLoggedIn()) {
      console.log('Utilisateur non connecté, redirection vers login');
      this.router.navigate(['/login']);
      return;
    }
    
    console.log('Utilisateur connecté, token:', this.authService.getToken());
  }

  onSubmit(): void {
    console.log('Soumission du formulaire...');
    console.log('Formulaire valide:', this.plantForm.valid);
    console.log('Valeurs du formulaire:', this.plantForm.value);
    
    if (!this.authService.isLoggedIn()) {
      this.errorMessage = 'Vous devez être connecté pour ajouter une plante.';
      return;
    }

    if (this.plantForm.valid) {
      this.isLoading = true;
      this.errorMessage = '';
      this.successMessage = '';

      const plantDto: PlantDto = this.plantForm.value;
      console.log('Données à envoyer:', plantDto);

      this.plantService.createPlant(plantDto).subscribe({
        next: (plant) => {
          console.log('Plante créée avec succès:', plant);
          this.successMessage = `Plante "${plant.name}" ajoutée avec succès !`;
          this.isLoading = false;
          setTimeout(() => {
            this.router.navigate(['/plants']);
          }, 2000);
        },
        error: (error) => {
          console.error('Erreur lors de l\'ajout:', error);
          this.errorMessage = `Erreur lors de l'ajout de la plante: ${error.message || 'Erreur inconnue'}`;
          this.isLoading = false;
        }
      });
    } else {
      this.markFormGroupTouched();
      console.log('Formulaire invalide:', this.plantForm.errors);
      console.log('Erreurs par champ:', this.getFormErrors());
      this.errorMessage = 'Veuillez corriger les erreurs dans le formulaire.';
    }
  }

  private markFormGroupTouched(): void {
    Object.keys(this.plantForm.controls).forEach(key => {
      const control = this.plantForm.get(key);
      control?.markAsTouched();
    });
  }

  private getFormErrors(): any {
    const errors: any = {};
    Object.keys(this.plantForm.controls).forEach(key => {
      const control = this.plantForm.get(key);
      if (control?.errors) {
        errors[key] = control.errors;
      }
    });
    return errors;
  }

  goBack(): void {
    this.router.navigate(['/plants']);
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  getFieldError(fieldName: string): string {
    const field = this.plantForm.get(fieldName);
    if (field?.errors && field.touched) {
      if (field.errors['required']) {
        return 'Ce champ est requis';
      }
      if (field.errors['minlength']) {
        return `Minimum ${field.errors['minlength'].requiredLength} caractères`;
      }
    }
    return '';
  }
}
