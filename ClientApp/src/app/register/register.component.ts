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
    isJefeCarrera: boolean = false; // Variable para alternar los campos de jefe de carrera
    carrerasInvalid: boolean = false; // Para mostrar error si no selecciona entre 1 y 3 carreras
    listaCarreras: string[] = [
        'Ingeniería de Software', 'Ingeniería Civil', 'Arquitectura', 'Medicina', 'Derecho', 'Psicología', 'Educación', 'Administración de Empresas'
    ];

    constructor(private formBuilder: FormBuilder, private router: Router) { }

    ngOnInit(): void {
        // Inicializamos el formulario con los campos básicos
        this.registerForm = this.formBuilder.group({
            nombre: ['', Validators.required],
            telefono: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
            ci: ['', Validators.required],
            fechaNacimiento: ['', Validators.required],
            correo: ['', [Validators.required, Validators.email]],
            contrasena: ['', [Validators.required, Validators.minLength(6)]],
            contrasenaRep: ['', [Validators.required, Validators.minLength(6)]],
            // Campos adicionales para jefe de carrera
            carreras: [[], [this.carrerasValidator()]], // Validación personalizada
            grado: [''],
            anosExperiencia: [''],
            departamento: ['']
        });
    }

    // Validador personalizado para las carreras
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
            this.registerForm.get('grado')?.setValidators(Validators.required);
            this.registerForm.get('anosExperiencia')?.setValidators([Validators.required, Validators.min(1)]);
            this.registerForm.get('departamento')?.setValidators(Validators.required);
        } else {
            // Si se deselecciona, removemos las validaciones
            this.registerForm.get('carreras')?.clearValidators();
            this.registerForm.get('grado')?.clearValidators();
            this.registerForm.get('anosExperiencia')?.clearValidators();
            this.registerForm.get('departamento')?.clearValidators();
        }

        // Actualizamos el estado de los campos adicionales
        this.registerForm.get('carreras')?.updateValueAndValidity();
        this.registerForm.get('grado')?.updateValueAndValidity();
        this.registerForm.get('anosExperiencia')?.updateValueAndValidity();
        this.registerForm.get('departamento')?.updateValueAndValidity();
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

        // Validación personalizada para el campo "carreras"
        if (this.isJefeCarrera && (this.registerForm.value.carreras.length < 1 || this.registerForm.value.carreras.length > 3)) {
            this.carrerasInvalid = true;
            return;
        } else {
            this.carrerasInvalid = false;
        }

        // Simulación de registro
        console.log('Datos del formulario:', this.registerForm.value);

        alert('Registro exitoso');
        this.router.navigate(['/login']);
    }
}
