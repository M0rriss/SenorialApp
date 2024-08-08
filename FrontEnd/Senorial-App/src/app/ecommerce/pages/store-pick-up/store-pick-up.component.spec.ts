import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StorePickUpComponent } from './store-pick-up.component';

describe('StorePickUpComponent', () => {
  let component: StorePickUpComponent;
  let fixture: ComponentFixture<StorePickUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StorePickUpComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StorePickUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
