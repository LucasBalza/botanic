import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { PlantListComponent } from './components/plant-list/plant-list.component';
import { PlantDetailComponent } from './components/plant-detail/plant-detail.component';
import { PlantAddComponent } from './components/plant-add/plant-add.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'plants', component: PlantListComponent },
  { path: 'plants/add', component: PlantAddComponent },
  { path: 'plants/:id', component: PlantDetailComponent },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
