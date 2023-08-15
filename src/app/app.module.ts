import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { InputDefaultComponent } from './components/shared/input/input-default/input-default.component';
import {ReactiveFormsModule } from '@angular/forms';
import { SidebarComponent } from './components/shared/sidebar/sidebar.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { MuralComponent } from './components/dashboard/mural/mural.component';
import { CardContagemComponent } from './components/dashboard/card-contagem/card-contagem.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    InputDefaultComponent,
    SidebarComponent,
    DashboardComponent,
    MuralComponent,
    CardContagemComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }