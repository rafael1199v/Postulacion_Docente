import { Usuario } from "./usuario.interface";

export interface Docente{
    datosPersonales : Usuario,
    materia : string,
    experiencia : number,
    grado : string
}