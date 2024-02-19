import { Component } from '@angular/core';
import { ExchangeRatesService } from 'src/app/api-proxy-services/exchange-rates/exchange-rates.service';
import {
    DailyExchangeRatesDto,
    SavedDailyExchangeRatesDto,
} from 'src/app/api-proxy-services/models/types';

@Component({
    selector: 'app-current-exchange-rate',
    templateUrl: './current-exchange-rate.component.html',
    styleUrls: ['./current-exchange-rate.component.scss'],
})
export class CurrentExchangeRateComponent {
    savedCurrent?: SavedDailyExchangeRatesDto;
    current?: DailyExchangeRatesDto;
    constructor(public service: ExchangeRatesService) {
        service.getCurrent().subscribe((r) => {
            this.current = r;
            service.getSavedCurrent().subscribe((r) => {
                this.savedCurrent = r;
            });
        });
    }
}
