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
import { ConfiguracaoComponent } from './components/configuracao/configuracao.component';
import { DialogOkComponent } from './components/shared/dialog/dialog-ok/dialog-ok.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatDialogModule} from '@angular/material/dialog';
import { ListagemLoteComponent } from './components/listagem-lote/listagem-lote.component';
import { CardComponent } from './components/listagem-lote/card/card.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    InputDefaultComponent,
    SidebarComponent,
    DashboardComponent,
    MuralComponent,
    CardContagemComponent,
    ConfiguracaoComponent,
    DialogOkComponent,
    ListagemLoteComponent,
    CardComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
