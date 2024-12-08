import { Component } from '@angular/core';
import { Vacante } from '../models/interfaces/vacante.interface';
import { Router } from '@angular/router';
import { vacanteService } from '../services/vacanteService';


@Component({
  selector: 'app-vacantes-disponibles',
  templateUrl: './vacantes-disponibles.component.html',
  styleUrls: ['./vacantes-disponibles.component.css']
})
export class VacantesDisponiblesComponent {
  vacantes: Vacante[] = [];

  constructor(private router: Router, private vacanteService: vacanteService){
    this.vacanteService.GetVacantesDisponibles().subscribe(result => {
      this.vacantes = result;
      console.log(result);
    }, error => console.log(error));
  }


}
