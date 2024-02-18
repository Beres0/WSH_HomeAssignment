import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SavedExchangeRateComponent } from './saved-exchange-rate.component';

describe('SavedExchangeRateComponent', () => {
  let component: SavedExchangeRateComponent;
  let fixture: ComponentFixture<SavedExchangeRateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SavedExchangeRateComponent]
    });
    fixture = TestBed.createComponent(SavedExchangeRateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
