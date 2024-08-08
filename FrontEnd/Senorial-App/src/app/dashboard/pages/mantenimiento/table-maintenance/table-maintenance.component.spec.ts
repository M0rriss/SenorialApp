import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableMaintenanceComponent } from './table-maintenance.component';

describe('TableMaintenanceComponent', () => {
  let component: TableMaintenanceComponent;
  let fixture: ComponentFixture<TableMaintenanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TableMaintenanceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TableMaintenanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
