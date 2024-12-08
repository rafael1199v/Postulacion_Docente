import { Component } from '@angular/core';
import { LoginData } from '../models/interfaces/login.interface';
import { LoginService } from '../services/loginService';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginForm: FormGroup;

  constructor(private loginService: LoginService, private router: Router){
    this.loginForm = this.loginService.loginFormBuilder();
  }

  login(){

    if(!this.loginForm.valid){
      console.log("Datos faltantes o incorrectos");
    }
    else{

      let loginData : LoginData = {
        email : this.loginForm.value.email,
        password: this.loginForm.value.password
      };
  
      console.log("Verificando credenciales");
      this.loginService.login(loginData).subscribe( result => {
        sessionStorage.setItem('usuarioCI', result.usuarioCI);
        //console.log(result.usuarioCI)
        this.router.navigate(['/']);
      }, error => console.log(error));
    }
    
   
  }
}
