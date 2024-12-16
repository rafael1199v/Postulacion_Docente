import { Component } from '@angular/core';
import { Vacante } from '../models/interfaces/vacante.interface';
import { vacanteService } from '../services/vacanteService';
import { ActivatedRoute, Router } from '@angular/router';
import { GetSessionRole } from '../services/GetSessionRole';

@Component({
  selector: 'app-habilitar-vacante',
  templateUrl: './habilitar-vacante.component.html',
  styleUrls: ['./habilitar-vacante.component.css']
})
export class HabilitarVacanteComponent {
  public role:any;
  vacante: Vacante | undefined;

  constructor(private vacanteService: vacanteService, private activatedRoute: ActivatedRoute, private router: Router){
    this.vacanteService.GetDetalleVacante(this.activatedRoute.snapshot.paramMap.get('vacanteId') || '-1').subscribe(result => {
      this.vacante = result;
      console.log(this.vacante);
    }, error => console.log(error));
    
    this.role = GetSessionRole;
  }

  Postularse(){
    const vacanteId = String(this.vacante?.vacanteId) || '-1';
    const fechaFinalizacion = this.vacante?.fechaFinalizacion || new Date(0);
    this.vacanteService.PutHabilitarVacante(vacanteId).subscribe(result => {
      alert(result.mensaje);
      this.router.navigate(['/vacantes-esperando']);
    },error => alert(error));
  }
}
