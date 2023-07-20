import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequirementRequestComponent } from './requirement-request.component';

describe('RequirementRequestComponent', () => {
  let component: RequirementRequestComponent;
  let fixture: ComponentFixture<RequirementRequestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RequirementRequestComponent]
    });
    fixture = TestBed.createComponent(RequirementRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
