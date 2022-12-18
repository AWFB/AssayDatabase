import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LaboratoriesDetailComponent } from './laboratories-detail.component';

describe('LaboratoriesDetailComponent', () => {
  let component: LaboratoriesDetailComponent;
  let fixture: ComponentFixture<LaboratoriesDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LaboratoriesDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LaboratoriesDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
