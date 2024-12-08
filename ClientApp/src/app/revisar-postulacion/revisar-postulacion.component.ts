import { Component } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as FileSaver from 'file-saver'; 
import { PerfilService } from '../services/PerfilService';
import { Docente } from '../models/interfaces/docente.interface';

@Component({
  selector: 'app-revisar-postulacion',
  templateUrl: './revisar-postulacion.component.html',
  styleUrls: ['./revisar-postulacion.component.css']
})
export class RevisarPostulacionComponent {
  docente: Docente | undefined;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private perfilService: PerfilService){
    this.perfilService.obtenerDatosDocente().subscribe(result => {
      this.docente = result;
      console.log(this.docente);
    }); 
  }
}
