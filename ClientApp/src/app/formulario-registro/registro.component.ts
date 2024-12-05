import { Component } from '@angular/core';

@Component({
    selector: 'app-registro',
    templateUrl: './registro.component.html',
    styleUrls: ['./registro.component.css']
})
export class RegistroComponent {
    registro = {
        nombre: '',
        telefono: '',
        ci: '',
        fechaNacimiento: '',
        materia: '',
        grado: '',
        aniosExperiencia: 0,
        correo: '',
        contrasena: '',
        confirmarContrasena: ''
    };

    registrarse(): void {
        if (this.registro.contrasena !== this.registro.confirmarContrasena) {
            alert('Las contraseñas no coinciden.');
            return;
        }
        // Aquí puedes implementar el envío de los datos al backend
        console.log('Datos registrados:', this.registro);
        alert('Registro exitoso');
    }

    
}