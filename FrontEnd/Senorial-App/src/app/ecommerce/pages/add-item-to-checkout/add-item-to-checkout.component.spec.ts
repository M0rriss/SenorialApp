import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddItemToCheckoutComponent } from './add-item-to-checkout.component';

describe('AddItemToCheckoutComponent', () => {
  let component: AddItemToCheckoutComponent;
  let fixture: ComponentFixture<AddItemToCheckoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddItemToCheckoutComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddItemToCheckoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
