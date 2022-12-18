import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./components/home/home.component";
import {LaboratoriesListComponent} from "./components/laboratories/laboratories-list/laboratories-list.component";
import {LaboratoriesDetailComponent} from "./components/laboratories/laboratories-detail/laboratories-detail.component";
import {AssayListComponent} from "./components/assays/assay-list/assay-list.component";
import {AssayDetailComponent} from "./components/assays/assay-detail/assay-detail.component";
import {AuthGuard} from "./guards/auth.guard";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'laboratories', component: LaboratoriesListComponent},
      {path: 'laboratories/:id', component: LaboratoriesDetailComponent},
    ]
  },

  {path: 'assays', component: AssayListComponent},
  {path: 'assays/:id', component: AssayDetailComponent},
  {path: '**', component: HomeComponent, pathMatch: 'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
