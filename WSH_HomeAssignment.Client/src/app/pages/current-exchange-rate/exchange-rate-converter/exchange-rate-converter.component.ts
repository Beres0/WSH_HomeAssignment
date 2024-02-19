import { Component, Input } from '@angular/core';
import {
    DailyExchangeRatesDto,
    ExchangeRateDto,
} from 'src/app/api-proxy-services/models/types';

@Component({
    selector: 'app-exchange-rate-converter',
    templateUrl: './exchange-rate-converter.component.html',
    styleUrls: ['./exchange-rate-converter.component.scss'],
})
export class ExchangeRateConverterComponent {
    @Input() current?: DailyExchangeRatesDto;
    from = 'HUF';
    to = 'EUR';
    fromUnit: number = 0;

    huf: ExchangeRateDto = {
        currency: 'HUF',
        unit: 1,
        value: 1,
    };

    calculate() {
        const fromRate: ExchangeRateDto =
            this.from == 'HUF'
                ? this.huf
                : (this.current?.exchangeRates as any)[this.from];
        const toRate: ExchangeRateDto =
            this.to == 'HUF'
                ? this.huf
                : (this.current?.exchangeRates as any)[this.to];
        return (
            Math.round(
                ((this.fromUnit * fromRate.value) /
                    (toRate.unit * toRate.value * fromRate.unit)) *
                    100
            ) / 100
        );
    }
}
