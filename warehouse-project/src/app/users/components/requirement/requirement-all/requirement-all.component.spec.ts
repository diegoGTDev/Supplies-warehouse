import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequirementAllComponent } from './requirement-all.component';

describe('RequirementAllComponent', () => {
  let component: RequirementAllComponent;
  let fixture: ComponentFixture<RequirementAllComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RequirementAllComponent]
    });
    fixture = TestBed.createComponent(RequirementAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
