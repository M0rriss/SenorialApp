import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuListEcommerceComponent } from './menu-list-ecommerce.component';

describe('MenuListEcommerceComponent', () => {
  let component: MenuListEcommerceComponent;
  let fixture: ComponentFixture<MenuListEcommerceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MenuListEcommerceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MenuListEcommerceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
