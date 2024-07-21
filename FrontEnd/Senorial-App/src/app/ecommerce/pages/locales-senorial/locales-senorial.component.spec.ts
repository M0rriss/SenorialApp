import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LocalesSenorialComponent } from './locales-senorial.component';

describe('LocalesSenorialComponent', () => {
  let component: LocalesSenorialComponent;
  let fixture: ComponentFixture<LocalesSenorialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LocalesSenorialComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LocalesSenorialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
