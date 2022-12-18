import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {NavComponent} from './components/nav/nav.component';
import {FormsModule} from "@angular/forms";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/register/register.component';
import { AssayListComponent } from './components/assays/assay-list/assay-list.component';
import { AssayDetailComponent } from './components/assays/assay-detail/assay-detail.component';
import { LaboratoriesListComponent } from './components/laboratories/laboratories-list/laboratories-list.component';
import { LaboratoriesDetailComponent } from './components/laboratories/laboratories-detail/laboratories-detail.component';
import {SharedModule} from "./modules/shared.module";
import {ErrorInterceptor} from "./interceptors/error.interceptor";
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    AssayListComponent,
    AssayDetailComponent,
    LaboratoriesListComponent,
    LaboratoriesDetailComponent,
    NotFoundComponent,
    ServerErrorComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    SharedModule
  ],
  providers: [{provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule {
}
