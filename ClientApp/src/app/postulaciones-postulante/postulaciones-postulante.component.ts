import { Component } from '@angular/core';
import { Postulacion } from '../models/interfaces/postulacion.interface';
import { PostulacionService } from '../services/PostulacionService';

@Component({
  selector: 'app-postulaciones-postulante',
  templateUrl: './postulaciones-postulante.component.html',
  styleUrls: ['./postulaciones-postulante.component.css']
})
export class PostulacionesPostulanteComponent {
  postulaciones: Postulacion[] = [];


  constructor(private postulacionService: PostulacionService){
    this.postulacionService.ConseguirPostulacionesVigentes().subscribe( result => {
      console.log(result);
      this.postulaciones = result;
    }, error => console.log(error));
  }
}
