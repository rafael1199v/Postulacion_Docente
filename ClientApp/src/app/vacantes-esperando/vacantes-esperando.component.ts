import { Component } from '@angular/core';
import { VacanteJefe } from '../models/interfaces/vacanteJefe.interface';
import { vacanteService } from '../services/vacanteService';
import { ActivatedRoute } from '@angular/router';
import { GetSessionRole } from '../services/GetSessionRole';


@Component({
  selector: 'app-vacantes-esperando',
  templateUrl: './vacantes-esperando.component.html',
  styleUrls: ['./vacantes-esperando.component.css']
})
export class VacantesEsperandoComponent {

  vacantes: VacanteJefe[] = []
  public role:any;
  constructor(private vacanteSerivce: vacanteService)
  {
    this.vacanteSerivce.GetVacantesPendientes().subscribe(result => {
      this.vacantes = result;
      console.log(this.vacantes);
    }, error => console.log(error));
    this.role = GetSessionRole;
  } 
}
