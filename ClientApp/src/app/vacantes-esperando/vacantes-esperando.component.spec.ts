import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VacantesEsperandoComponent } from './vacantes-esperando.component';

describe('VacantesEsperandoComponent', () => {
  let component: VacantesEsperandoComponent;
  let fixture: ComponentFixture<VacantesEsperandoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VacantesEsperandoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VacantesEsperandoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
