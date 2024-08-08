import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentMethodMaintenanceComponent } from './payment-method-maintenance.component';

describe('PaymentMethodMaintenanceComponent', () => {
  let component: PaymentMethodMaintenanceComponent;
  let fixture: ComponentFixture<PaymentMethodMaintenanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PaymentMethodMaintenanceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PaymentMethodMaintenanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
