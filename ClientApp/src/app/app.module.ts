import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login.component';

import { VacanteComponent } from './vacante/vacante.component';
import { vacanteService } from './services/vacanteService';
import { LoginService } from './services/loginService';
import { FooterComponent } from './footer/footer.component';
import { ComunidadComponent } from './comunidad/comunidad.component';
import { AyudaComponent } from './ayuda/ayuda.component';
import { ReglamentoComponent } from './reglamento/reglamento.component';
import { ProfileComponent } from './profile/profile.component';
import { RegistroComponent } from './formulario-registro/registro.component'


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    VacanteComponent,
    FooterComponent,
    ComunidadComponent,
    AyudaComponent,
    ReglamentoComponent,
    ProfileComponent,
    RegistroComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginComponent },
      { path: 'vacante', component: VacanteComponent },
      { path: 'footer', component: FooterComponent },
      { path: 'comunidad', component: ComunidadComponent },
      { path: 'ayuda', component: AyudaComponent },
      { path: 'reglamento', component: ReglamentoComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'register', component: RegistroComponent },
    ])
  ],
  providers: [vacanteService, LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
