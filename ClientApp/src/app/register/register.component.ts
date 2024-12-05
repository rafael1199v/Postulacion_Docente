import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioService } from '../services/UsuarioService';
import { Router } from '@angular/router';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
    registerForm!: FormGroup;

    constructor(
        private formBuilder: FormBuilder,
        private usuarioService: UsuarioService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.registerForm = this.formBuilder.group({
            nombre: ['', Validators.required],
            direccion: ['', Validators.required],
            fechaNacimiento: ['', Validators.required],
            correo: ['', [Validators.required, Validators.email]],
            prefijo: ['+591', Validators.required],
            telefono: [
                '',
                [Validators.required, Validators.minLength(8), Validators.maxLength(8)],
            ],
            organizacion: ['', Validators.required],
            cargo: ['', Validators.required],
            contrasenha: ['', [Validators.required, Validators.minLength(5)]],
            contrasenhaRep: ['', [Validators.required, Validators.minLength(5)]],
        });
    }

    registrarUsuario() {
        if (!this.registerForm.valid) {
            alert('Campos inválidos');
        } else if (
            this.registerForm.value.contrasenha !==
            this.registerForm.value.contrasenhaRep
        ) {
            alert('Las contraseñas no coinciden');
        } else {
            this.usuarioService.registrarUsuario(this.registerForm.value).subscribe(
                () => {
                    alert('Usuario registrado con éxito');
                    this.router.navigate(['/login']);
                },
                (error) => console.error(error)
            );
        }
    }
}
