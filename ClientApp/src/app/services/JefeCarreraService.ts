import { HttpClient } from "@angular/common/http";
import { Injectable, Inject } from "@angular/core";
import { DocenteDatosPostulacion } from "../models/interfaces/docenteDatosPostulacion.interface";


@Injectable()
export class JefeCarreraService
{
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl : string){}


    GetSolicitudes(vacanteId: number){
        return this.http.get<DocenteDatosPostulacion[]>(this.baseUrl + 'jefeCarrera/verSolitciudes/' + vacanteId);
    }

    
    RevisarPostulacion(postulacionId: number){
        return this.http.get<DocenteDatosPostulacion>(this.baseUrl + 'jefeCarrera/revisarPostulacion/' + postulacionId);
    }
}