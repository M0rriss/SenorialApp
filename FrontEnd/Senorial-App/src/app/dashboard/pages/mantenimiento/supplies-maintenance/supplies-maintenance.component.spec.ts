import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuppliesMaintenanceComponent } from './supplies-maintenance.component';

describe('SuppliesMaintenanceComponent', () => {
  let component: SuppliesMaintenanceComponent;
  let fixture: ComponentFixture<SuppliesMaintenanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SuppliesMaintenanceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SuppliesMaintenanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
