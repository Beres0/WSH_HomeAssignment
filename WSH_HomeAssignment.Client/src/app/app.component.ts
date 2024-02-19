import { Component, OnInit } from '@angular/core';
import { AuthService } from './api-proxy-services/auth/auth.service';
import { ExchangeRatesService } from './api-proxy-services/exchange-rates/exchange-rates.service';
import { ValidationStoreService } from './api-proxy-services/validation/validation-store.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
    title = 'WSH_HomeAssignment.Client';
    constructor(
        private authService: AuthService,
        private validationService: ValidationStoreService
    ) {}
    async ngOnInit() {
        await this.validationService.getValues();
    }
    isLoggedIn() {
        return this.authService.isLoggedIn();
    }
}
