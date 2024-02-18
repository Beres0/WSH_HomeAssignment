import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SavedExchangeRateListComponent } from './saved-exchange-rate-list.component';

describe('SavedExchangeRateListComponent', () => {
  let component: SavedExchangeRateListComponent;
  let fixture: ComponentFixture<SavedExchangeRateListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SavedExchangeRateListComponent]
    });
    fixture = TestBed.createComponent(SavedExchangeRateListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
