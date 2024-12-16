import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HabilitarVacanteComponent } from './habilitar-vacante.component';

describe('HabilitarVacanteComponent', () => {
  let component: HabilitarVacanteComponent;
  let fixture: ComponentFixture<HabilitarVacanteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HabilitarVacanteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HabilitarVacanteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
