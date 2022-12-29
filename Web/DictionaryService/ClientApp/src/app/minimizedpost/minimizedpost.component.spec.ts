import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MinimizedpostComponent } from './minimizedpost.component';

describe('MinimizedpostComponent', () => {
  let component: MinimizedpostComponent;
  let fixture: ComponentFixture<MinimizedpostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MinimizedpostComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MinimizedpostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
