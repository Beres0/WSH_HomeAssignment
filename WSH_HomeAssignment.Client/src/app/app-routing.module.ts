import { NgModule } from '@angular/core';
import { mapToCanActivate, RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth-guard/auth.guard';
import { UnAuthGuard } from './auth-guard/un-auth.guard';
import { CurrentExchangeRateComponent } from './pages/current-exchange-rate/current-exchange-rate.component';
import { LoginComponent } from './pages/login/login.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { SavedExchangeRateListComponent } from './pages/saved-exchange-rate-list/saved-exchange-rate-list.component';

const routes: Routes = [
  {
    path: '',
    component: CurrentExchangeRateComponent,
    canActivate: mapToCanActivate([AuthGuard]),
  },
  {
    path: 'saved',
    component: SavedExchangeRateListComponent,
    canActivate: mapToCanActivate([AuthGuard]),
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate: mapToCanActivate([UnAuthGuard]),
  },
  {
    path: 'registration',
    component: RegistrationComponent,
    canActivate: mapToCanActivate([UnAuthGuard]),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
