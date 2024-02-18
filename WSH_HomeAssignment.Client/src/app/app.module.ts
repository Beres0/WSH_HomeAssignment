import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { LoginComponent } from './pages/login/login.component';
import { ExchangeRateTableComponent } from './pages/current-exchange-rate/exchange-rate-table/exchange-rate-table.component';
import { ExchangeRateConverterComponent } from './pages/current-exchange-rate/exchange-rate-converter/exchange-rate-converter.component';
import { SavedExchangeRateComponent } from './pages/saved-exchange-rate-list/saved-exchange-rate/saved-exchange-rate.component';
import { SavedExchangeRateListComponent } from './pages/saved-exchange-rate-list/saved-exchange-rate-list.component';
import { AuthInterceptor } from './interceptors/auth-interceptor';
import { CurrentExchangeRateComponent } from './pages/current-exchange-rate/current-exchange-rate.component';
import { NavbarComponent } from './navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { FormsModule }   from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DtoToDatePipe } from './pipes/dtoToDate-pipe';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ExchangeRateTableComponent,
    ExchangeRateConverterComponent,
    SavedExchangeRateComponent,
    SavedExchangeRateListComponent,
    RegistrationComponent,
    CurrentExchangeRateComponent,
    NavbarComponent,
    DtoToDatePipe,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
  ],
  exports: [
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS,useClass:AuthInterceptor,multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
