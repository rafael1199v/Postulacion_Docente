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
    carrerasInvalid: boolean = false;
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

    listaMaterias: string[] = [
        'Matemáticas', 'Física', 'Química', 'Historia', 'Geografía', 'Biología'
    ]; // Lista de materias

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
            materia: [[], [Validators.required, this.materiaValidator()]], // Cambiado a array para permitir múltiples seleccionados
            grado: ['', Validators.required],
            anosExperiencia: ['', [Validators.required, Validators.min(1)]],
            carreras: [[], [this.carrerasValidator()]] // Validación personalizada para carreras
        });
    }

    // Validador personalizado para materias
    materiaValidator() {
        return (control: any) => {
            const selectedMaterias = control.value;
            if (selectedMaterias.length < 1 || selectedMaterias.length > 3) {
                return { invalidMaterias: true };
            }
            return null;
        };
    }

    // Validador personalizado para carreras
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

        if (this.isJefeCarrera) {
            this.registerForm.get('carreras')?.setValidators([Validators.required, this.carrerasValidator()]);
            this.registerForm.get('materia')?.setValidators([Validators.required, this.materiaValidator()]);
        } else {
            this.registerForm.get('carreras')?.clearValidators();
            this.registerForm.get('materia')?.clearValidators();
        }

        this.registerForm.get('carreras')?.updateValueAndValidity();
        this.registerForm.get('materia')?.updateValueAndValidity();
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

        if (
            this.isJefeCarrera &&
            (this.registerForm.value.carreras.length < 1 || this.registerForm.value.carreras.length > 3)
        ) {
            this.carrerasInvalid = true;
            return;
        } else {
            this.carrerasInvalid = false;
        }

        console.log('Datos del formulario:', this.registerForm.value);
        alert('Registro exitoso');
        this.router.navigate(['/login']);
    }
}
