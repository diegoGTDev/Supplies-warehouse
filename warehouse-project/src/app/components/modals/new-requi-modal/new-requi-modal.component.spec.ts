import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewRequiModalComponent } from './new-requi-modal.component';

describe('NewRequiModalComponent', () => {
  let component: NewRequiModalComponent;
  let fixture: ComponentFixture<NewRequiModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewRequiModalComponent]
    });
    fixture = TestBed.createComponent(NewRequiModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
