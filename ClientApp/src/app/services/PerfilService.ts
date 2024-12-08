import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Docente } from '../models/interfaces/docente.interface';

@Injectable()
export class PerfilService {

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl : string) { }

    obtenerDatosDocente(){
        return this.http.get<Docente>(this.baseUrl + "docente/conseguirDatosDocente/" + sessionStorage.getItem('usuarioCI'));
    }

    obtenerDatosJefeCarrera()
    {

    }
}