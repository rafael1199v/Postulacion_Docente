import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";

@Injectable()
export class loginService
{
    http : HttpClient;
    baseUrl : string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
    {
        this.http = http;
        this.baseUrl = baseUrl;
    }


    login(email : string, password: string)
    {   
        const datosLogin = {
            Email : email,
            Password : password
        };

        return this.http.post<any>(this.baseUrl + 'usuario/login', datosLogin);
    }
}