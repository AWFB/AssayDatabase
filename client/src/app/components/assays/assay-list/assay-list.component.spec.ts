import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssayListComponent } from './assay-list.component';

describe('AssayListComponent', () => {
  let component: AssayListComponent;
  let fixture: ComponentFixture<AssayListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssayListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssayListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
