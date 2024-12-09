import { Component } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PerfilService } from '../services/PerfilService';
import { Jefe } from '../models/interfaces/jefe.interface';

@Component({
  selector: 'app-nav-menu-jefe',
  templateUrl: './nav-menu-jefe.component.html',
  styleUrls: ['./nav-menu-jefe.component.css']
})
export class NavMenuJefeComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }


  CerrarSesion(){
    sessionStorage.removeItem('usuarioCI');
  }
  
  jefeCarrera: Jefe | undefined;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private perfilService: PerfilService){
    this.perfilService.obtenerDatosJefeCarrera().subscribe(result => {
      this.jefeCarrera = result;
      console.log(this.jefeCarrera);
    }); 
  }
}