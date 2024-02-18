import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExchangeRateConverterComponent } from './exchange-rate-converter.component';

describe('ExchangeRateConverterComponent', () => {
  let component: ExchangeRateConverterComponent;
  let fixture: ComponentFixture<ExchangeRateConverterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExchangeRateConverterComponent]
    });
    fixture = TestBed.createComponent(ExchangeRateConverterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
