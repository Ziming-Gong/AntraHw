import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorAddComponent } from './vendor-add.component';

describe('VendorAddComponent', () => {
  let component: VendorAddComponent;
  let fixture: ComponentFixture<VendorAddComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VendorAddComponent]
    });
    fixture = TestBed.createComponent(VendorAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
