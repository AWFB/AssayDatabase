import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssayDetailComponent } from './assay-detail.component';

describe('AssayDetailComponent', () => {
  let component: AssayDetailComponent;
  let fixture: ComponentFixture<AssayDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssayDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssayDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
