import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
    registerForm!: FormGroup;
    isJefeCarrera: boolean = false;
    listaCarreras: string[] = [
        'Ingeniería de Software',
        'Ingeniería Civil',
        'Arquitectura',
        'Medicina',
        'Derecho',
        'Psicología',
        'Educación',
        'Administración de Empresas'
    ];

    constructor(private formBuilder: FormBuilder, private router: Router) { }

    ngOnInit(): void {
        this.registerForm = this.formBuilder.group({
            nombre: ['', Validators.required],
            telefono: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
            ci: ['', Validators.required],
            fechaNacimiento: ['', Validators.required],
            correo: ['', [Validators.required, Validators.email]],
            contrasena: ['', [Validators.required, Validators.minLength(6)]],
            contrasenaRep: ['', [Validators.required, Validators.minLength(6)]],
            grado: ['', Validators.required],
            anosExperiencia: ['', [Validators.required, Validators.min(1)]],
            carreras: [[], [Validators.required, this.carrerasValidator()]] // Campo para las carreras seleccionadas
        });
    }

    // Función para validar las carreras seleccionadas (1 a 3 carreras)
    carrerasValidator() {
        return (control: any) => {
            const selectedCarreras = control.value;
            if (selectedCarreras.length < 1 || selectedCarreras.length > 3) {
                return { invalidCarreras: true };
            }
            return null;
        };
    }

    toggleJefeCarrera(): void {
        this.isJefeCarrera = !this.isJefeCarrera;
        const carrerasControl = this.registerForm.get('carreras');

        if (this.isJefeCarrera) {
            carrerasControl?.setValidators([Validators.required, this.carrerasValidator()]);
        } else {
            carrerasControl?.clearValidators();
        }

        carrerasControl?.updateValueAndValidity();
    }

    // Método que maneja el cambio de los checkboxes
    onCarreraChange(event: any): void {
        const selectedCarreras = this.registerForm.value.carreras || [];

        // Si el checkbox está marcado, lo agregamos a las selecciones
        if (event.target.checked) {
            if (selectedCarreras.length < 3) {
                selectedCarreras.push(event.target.value);
            } else {
                event.target.checked = false; // Si ya hay 3 carreras seleccionadas, desmarcamos el checkbox
            }
        } else {
            // Si el checkbox está desmarcado, lo eliminamos de las selecciones
            const index = selectedCarreras.indexOf(event.target.value);
            if (index > -1) {
                selectedCarreras.splice(index, 1);
            }
        }

        // Actualizamos el valor en el FormGroup
        this.registerForm.patchValue({ carreras: selectedCarreras });
    }

    // Método que determina si una carrera está seleccionada
    isCarreraSelected(carrera: string): boolean {
        const selectedCarreras = this.registerForm.value.carreras || [];
        return selectedCarreras.includes(carrera);
    }

    registrarUsuario(): void {
        if (!this.registerForm.valid) {
            alert('Por favor, completa todos los campos requeridos.');
            return;
        }

        if (this.registerForm.value.contrasena !== this.registerForm.value.contrasenaRep) {
            alert('Las contraseñas no coinciden.');
            return;
        }

        console.log('Datos del formulario:', this.registerForm.value);
        alert('Registro exitoso');
        this.router.navigate(['/login']);
    }
}
