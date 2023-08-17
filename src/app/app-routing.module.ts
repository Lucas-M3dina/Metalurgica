import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AutorizadoGuard } from './guard/autorizado.guard';
import { ConfiguracaoComponent } from './components/configuracao/configuracao.component';
import { ListagemLoteComponent } from './components/listagem-lote/listagem-lote.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AutorizadoGuard]
  },
  {
    path: 'configuracao',
    component: ConfiguracaoComponent,
    canActivate: [AutorizadoGuard]
  },
  {
    path: 'listagemlote',
    component: ListagemLoteComponent,
    canActivate: [AutorizadoGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
