import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentExchangeRateComponent } from './current-exchange-rate.component';

describe('CurrentExchangeRateComponent', () => {
    let component: CurrentExchangeRateComponent;
    let fixture: ComponentFixture<CurrentExchangeRateComponent>;

    beforeEach(() => {
        TestBed.configureTestingModule({
            declarations: [CurrentExchangeRateComponent],
        });
        fixture = TestBed.createComponent(CurrentExchangeRateComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
