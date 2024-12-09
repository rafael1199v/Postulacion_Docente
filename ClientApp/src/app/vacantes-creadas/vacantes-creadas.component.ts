import { Component } from '@angular/core';
import { Vacante } from '../models/interfaces/vacante.interface';
import { vacanteService } from '../services/vacanteService';
import { ActivatedRoute } from '@angular/router';
import { VacanteJefe } from '../models/interfaces/vacanteJefe.interface';


@Component({
  selector: 'app-vacantes-creadas',
  templateUrl: './vacantes-creadas.component.html',
  styleUrls: ['./vacantes-creadas.component.css']
})
export class VacantesCreadasComponent {

  vacantes: VacanteJefe[] = []
  constructor(private vacanteSerivce: vacanteService)
  {
    this.vacanteSerivce.GetVacantesDisponiblesJefe().subscribe(result => {
      this.vacantes = result;
      console.log(this.vacantes);
    }, error => console.log(error));
  } 
} 
