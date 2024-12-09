import { Component } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PerfilService } from '../services/PerfilService';
import { Docente } from '../models/interfaces/docente.interface';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
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

  docente: Docente | undefined;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private perfilService: PerfilService){
    this.perfilService.obtenerDatosDocente().subscribe(result => {
      this.docente = result;
      console.log(this.docente);
    }); 
  }
}
