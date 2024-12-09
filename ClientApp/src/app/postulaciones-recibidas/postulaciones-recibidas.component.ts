import { Component } from '@angular/core';
import { Docente } from '../models/interfaces/docente.interface';
import { DocenteDatosPostulacion } from '../models/interfaces/docenteDatosPostulacion.interface';
import { JefeCarreraService } from '../services/JefeCarreraService';
import { vacanteService } from '../services/vacanteService';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-postulaciones-recibidas',
  templateUrl: './postulaciones-recibidas.component.html',
  styleUrls: ['./postulaciones-recibidas.component.css']
})
export class PostulacionesRecibidasComponent {
  postulaciones: DocenteDatosPostulacion[] = [];

  constructor(private jefeCarreraSerivce: JefeCarreraService, private activatedRoute: ActivatedRoute){
    const vacanteId: number = parseInt(this.activatedRoute.snapshot.paramMap.get('vacanteId') || '-1');
    this.jefeCarreraSerivce.GetSolicitudes(vacanteId).subscribe( result => {
      this.postulaciones = result;
      console.log(this.postulaciones);
    }, error => console.log(error));
  }



}
