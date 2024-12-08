import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Materia } from '../models/interfaces/materia.interface';
import { vacanteService } from '../services/vacanteService';

@Component({
  selector: 'app-crear-vacante',
  templateUrl: './crear-vacante.component.html',
  styleUrls: ['./crear-vacante.component.css']
})
export class CrearVacanteComponent {

  vacanteForm: FormGroup = this.fb.group({
    nombreVacante: ['', [Validators.required]],
    materia: ['', [Validators.required]],
    descripcionVacante: ['', [Validators.required]],
    fechaInicio: ['', [Validators.required]],
    fechaFinalizacion: ['', [Validators.required]]
  });
  
  materias: Materia[] = [];
  CI: string = "13772115";

  constructor(private fb: FormBuilder, private vacanteService: vacanteService)
  {
    this.vacanteService.GetMateriasJefeCarrera(this.CI).subscribe(result => {
      this.materias = result;
      console.log(this.materias);
    })

    
  }

  submitForm()
  {
    if(this.vacanteForm.invalid)
    {
      console.log("Campos invalidos");
    }
    else if(new Date(this.vacanteForm.value.fechaInicio).getTime() == new Date(this.vacanteForm.value.fechaFinalizacion).getTime())
    {
      console.log("No se puede crear una vacante que termine en la misma fecha");
    }
    else if(new Date(this.vacanteForm.value.fechaInicio).getTime() > new Date(this.vacanteForm.value.fechaFinalizacion).getTime() || new Date(this.vacanteForm.value.fechaFinalizacion).getTime() < Date.now()){
      console.log("Error en las fechas");
    }
    else
    {
      console.log(this.vacanteForm.value);
    }
    
  }

}
