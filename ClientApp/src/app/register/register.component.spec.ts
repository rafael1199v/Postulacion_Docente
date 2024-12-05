import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RegisterComponent } from './register.component';
import { ReactiveFormsModule } from '@angular/forms';

describe('RegisterComponent', () => {
    let component: RegisterComponent;
    let fixture: ComponentFixture<RegisterComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [RegisterComponent],
            imports: [ReactiveFormsModule],
        }).compileComponents();

        fixture = TestBed.createComponent(RegisterComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create the component', () => {
        expect(component).toBeTruthy();
    });

    it('should invalidate the form when empty', () => {
        expect(component.registerForm.valid).toBeFalsy();
    });

    it('should validate the form with correct input', () => {
        component.registerForm.controls['nombre'].setValue('Juan Pérez');
        component.registerForm.controls['direccion'].setValue('Av. Principal 123');
        component.registerForm.controls['fechaNacimiento'].setValue('1990-01-01');
        component.registerForm.controls['correo'].setValue('juan@example.com');
        component.registerForm.controls['prefijo'].setValue('+591');
        component.registerForm.controls['telefono'].setValue('12345678');
        component.registerForm.controls['organizacion'].setValue('Empresa X');
        component.registerForm.controls['cargo'].setValue('Manager');
        component.registerForm.controls['contrasenha'].setValue('12345');
        component.registerForm.controls['contrasenhaRep'].setValue('12345');
        expect(component.registerForm.valid).toBeTruthy();
    });
});
