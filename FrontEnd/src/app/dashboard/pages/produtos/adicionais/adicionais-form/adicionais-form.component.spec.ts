import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionaisFormComponent } from './adicionais-form.component';

describe('AdicionaisFormComponent', () => {
  let component: AdicionaisFormComponent;
  let fixture: ComponentFixture<AdicionaisFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdicionaisFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionaisFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
