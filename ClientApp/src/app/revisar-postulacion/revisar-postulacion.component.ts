import { Component } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as FileSaver from 'file-saver'; 
import { PerfilService } from '../services/PerfilService';
import { Docente } from '../models/interfaces/docente.interface';
import { DocenteDatosPostulacion } from '../models/interfaces/docenteDatosPostulacion.interface';
import { JefeCarreraService } from '../services/JefeCarreraService';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-revisar-postulacion',
  templateUrl: './revisar-postulacion.component.html',
  styleUrls: ['./revisar-postulacion.component.css']
})
export class RevisarPostulacionComponent {
  
  postulacion: DocenteDatosPostulacion | undefined;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private jefeCarreraService: JefeCarreraService, private activatedRoute: ActivatedRoute){
    const postulacionId = parseInt(this.activatedRoute.snapshot.paramMap.get('postulacionId') || '-1');

    this.jefeCarreraService.RevisarPostulacion(postulacionId).subscribe(result => {
      this.postulacion = result;
      console.log(this.postulacion);
    }, error => console.log(error)); 
  }
}
