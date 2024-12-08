import { Component } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as FileSaver from 'file-saver'; 
import { PerfilService } from '../services/PerfilService';
import { Jefe } from '../models/interfaces/jefe.interface';

@Component({
  selector: 'app-profile-jefe',
  templateUrl: './profile-jefe.component.html',
  styleUrls: ['./profile-jefe.component.css']
})
export class ProfileJefeComponent {

  jefeCarrera: Jefe | undefined;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private perfilService: PerfilService){
    this.perfilService.obtenerDatosDocente().subscribe(result => {
      this.jefeCarrera = result;
      console.log(this.jefeCarrera);
    }); 
  }
}
