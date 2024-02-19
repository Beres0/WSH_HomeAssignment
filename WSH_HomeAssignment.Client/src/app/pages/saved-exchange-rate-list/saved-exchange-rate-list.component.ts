import { Component, ChangeDetectorRef } from '@angular/core';
import { ExchangeRatesService } from 'src/app/api-proxy-services/exchange-rates/exchange-rates.service';
import {
    PaginationArgs,
    PaginationDto,
    SavedExchangeRateDto,
} from 'src/app/api-proxy-services/models/types';
import { ValidationStoreService } from 'src/app/api-proxy-services/validation/validation-store.service';

@Component({
    selector: 'app-saved-exchange-rate-list',
    templateUrl: './saved-exchange-rate-list.component.html',
    styleUrls: ['./saved-exchange-rate-list.component.scss'],
})
export class SavedExchangeRateListComponent {
    noteMaxLength?: number = 0;
    totalCount: number = 0;
    items: SavedExchangeRateDto[] = [];
    args: PaginationArgs = {
        take: 10,
        skip: 0,
    };
    constructor(
        private service: ExchangeRatesService,
        validations: ValidationStoreService
    ) {
        validations.getValues().then((v) => {
            this.noteMaxLength = v.noteMaxLength;
        });
        this.loadData();
    }
    private loadData() {
        this.service.getSavedList(this.args).subscribe((r) => {
            this.items = r.result;
            this.totalCount = r.totalCount;
            console.log(r);
        });
    }
    more() {
        debugger;
        this.args.skip = this.items.length;
        this.service.getSavedList(this.args).subscribe((r) => {
            this.items.push(...r.result);
            this.totalCount = r.totalCount;
        });
    }
    confirm(e: SavedExchangeRateDto) {
        const note = e.note != '' ? e.note : undefined;
        this.service.updateSaved(e.date, e.currency, { note: note }).subscribe({
            error: (e) => {
                console.log(e);
                window.location.reload();
            },
        });
    }
    delete(e: SavedExchangeRateDto) {
        this.service.deleteSaved(e.date, e.currency).subscribe({
            next: (r) => {
                const index = this.items.findIndex((value) => {
                    return (
                        e.date.year == value.date.year &&
                        e.date.month == value.date.month &&
                        e.date.day == value.date.day &&
                        e.currency == value.currency
                    );
                });
                if (index != undefined) {
                    this.items.splice(index, 1);
                }
            },
            error: (e) => {
                console.log(e);
                window.location.reload();
            },
        });
    }
}
