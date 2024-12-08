import { Component } from '@angular/core';
import { Vacante } from '../models/interfaces/vacante.interface';
import { vacanteService } from '../services/vacanteService';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-postularse',
  templateUrl: './postularse.component.html',
  styleUrls: ['./postularse.component.css']
})
export class PostularseComponent {

  vacante: Vacante | undefined;

  constructor(private vacanteService: vacanteService, private activatedRoute: ActivatedRoute){
    this.vacanteService.GetDetalleVacante(this.activatedRoute.snapshot.paramMap.get('vacanteId') || '-1').subscribe(result => {
      this.vacante = result;
      console.log(this.vacante);
    }, error => console.log(error));
  }
}
