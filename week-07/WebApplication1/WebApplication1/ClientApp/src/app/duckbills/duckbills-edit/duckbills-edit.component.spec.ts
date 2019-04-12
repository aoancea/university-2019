import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DuckbillsEditComponent } from './duckbills-edit.component';

describe('DuckbillsEditComponent', () => {
  let component: DuckbillsEditComponent;
  let fixture: ComponentFixture<DuckbillsEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DuckbillsEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DuckbillsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
