import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BannerEcommerceComponent } from './banner-ecommerce.component';

describe('BannerEcommerceComponent', () => {
  let component: BannerEcommerceComponent;
  let fixture: ComponentFixture<BannerEcommerceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BannerEcommerceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BannerEcommerceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
