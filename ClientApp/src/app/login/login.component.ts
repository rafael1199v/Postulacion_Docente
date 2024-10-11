import { Component, Inject } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormGroup, FormBuilder, Form } from '@angular/forms';
import { loginService } from '../services/loginService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm! : FormGroup;

  constructor(private formBuilder : FormBuilder, @Inject('BASE_URL') private baseUrl: string, private loginService : loginService) {
    this.loginForm = formBuilder.group({
      email : ['', [Validators.required]],
      password : ['', [Validators.required]]
    })
  }

  login(){
    if(this.loginForm.valid){
      this.loginService.login(this.loginForm.value.email, this.loginForm.value.password).subscribe( result => {
        console.log(result);
      }, error => console.log(error));
    }
  }
  

}
