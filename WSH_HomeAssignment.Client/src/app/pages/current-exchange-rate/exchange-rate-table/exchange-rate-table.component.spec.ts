import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExchangeRateTableComponent } from './exchange-rate-table.component';

describe('ExchangeRateTableComponent', () => {
  let component: ExchangeRateTableComponent;
  let fixture: ComponentFixture<ExchangeRateTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExchangeRateTableComponent]
    });
    fixture = TestBed.createComponent(ExchangeRateTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
