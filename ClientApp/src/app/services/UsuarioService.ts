import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Docente } from '../models/interfaces/docente.interface';

@Injectable()
export class UsuarioService {
    private apiUrl = ''; // AQUI HAY QUE REEMPLAZAR CON LA URL DE NUESTRA API

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl : string) { }

    /**
     * Método para registrar un usuario.
     * @param usuario Datos del usuario a registrar
     * @returns Observable con la respuesta del servidor
     */
    registrarUsuario(usuario: any): Observable<any> {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.post(this.apiUrl, usuario, { headers });
    }

    /**
     * Método para obtener usuarios (opcional).
     * @returns Observable con la lista de usuarios
     */
    obtenerUsuarios(): Observable<any[]> {
        return this.http.get<any[]>(this.apiUrl);
    }

}
