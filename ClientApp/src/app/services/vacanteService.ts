import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Docente } from "../models/interfaces/docente.interface";
import { Materia } from "../models/interfaces/materia.interface";


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


    GetMateriasJefeCarrera(CI: string)
    {
        return this.http.get<Materia[]>(this.baseUrl + 'materia/conseguirMateriasJefeCarrera/' + CI);
    }
}