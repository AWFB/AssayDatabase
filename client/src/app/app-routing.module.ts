import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./components/home/home.component";
import {LaboratoriesListComponent} from "./components/laboratories/laboratories-list/laboratories-list.component";
import {LaboratoriesDetailComponent} from "./components/laboratories/laboratories-detail/laboratories-detail.component";
import {AssayListComponent} from "./components/assays/assay-list/assay-list.component";
import {AssayDetailComponent} from "./components/assays/assay-detail/assay-detail.component";
import {AuthGuard} from "./guards/auth.guard";
import {NotFoundComponent} from "./errors/not-found/not-found.component";
import {ServerErrorComponent} from "./errors/server-error/server-error.component";

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
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component: NotFoundComponent, pathMatch: 'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
