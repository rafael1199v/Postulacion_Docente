import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Docente } from "../models/interfaces/docente.interface";
import { Materia } from "../models/interfaces/materia.interface";
import { Vacante } from "../models/interfaces/vacante.interface";
import { NuevaPostulacion } from "../models/interfaces/nuevaPostulacion.interface";

@Injectable()
export class vacanteService{
    baseUrl : string;
    http : HttpClient

    constructor(http : HttpClient, @Inject('BASE_URL') baseUrl : string){
        this.baseUrl = baseUrl;
        this.http = http;
    }

    GetDocentesPostulacion(){
        return this.http.get<Docente>(this.baseUrl + 'docente/conseguirDocente/' + 13774782);
    }


    GetMateriasJefeCarrera(CI: string){
        return this.http.get<Materia[]>(this.baseUrl + 'materia/conseguirMateriasJefeCarrera/' + CI);
    }

    GetVacantesDisponibles(){
        return this.http.get<Vacante[]>(this.baseUrl + 'vacante/conseguirVacantesDisponibles/' + sessionStorage.getItem('usuarioCI'));
    }


    GetDetalleVacante(vacanteId: string){
        return this.http.get<Vacante>(this.baseUrl + 'vacante/conseguirDetalleVacante/' + vacanteId);
    }


    Postularse(vacanteId: number, fechaFinalizacionVacanteA: Date){
        const nuevaPostulacion: NuevaPostulacion = {
            vacanteId: vacanteId,
            ci: sessionStorage.getItem('usuarioCI') || '-1',
            fechaFinalizacionVacante: fechaFinalizacionVacanteA
        };

        return this.http.post<any>(this.baseUrl + 'docente/postularse', nuevaPostulacion);
    }
}