import { Component } from '@angular/core';
import { RouteToken } from './models/enums/route.enum';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  tokenRouter: RouteToken = RouteToken.Home;
  title = 'app';

  constructor(private activadedRoute : ActivatedRoute, private router: Router){

    if(sessionStorage.getItem('usuarioCI') == null)
    {
      this.router.navigate(['/login']);
    }

    this.router.events.subscribe((e) => {
      if (e instanceof NavigationEnd) {
        switch(e.url)
        {
          case'/login':
            this.tokenRouter = RouteToken.Login;
            break;
          case '/register':
            this.tokenRouter = RouteToken.Register;
            break;
          case '/':
            this.tokenRouter = RouteToken.Home;
            break;
          default:
            this.tokenRouter = RouteToken.Other;
        }
      }
    });
  }

  getSession(){
    if(sessionStorage.getItem('isJefe') == 'true'){
      return true;
    }
    return false;
  }

}
