import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AutenticacionService } from './_servicios/autenticacion.service';
import { InicioComponent } from './inicio/inicio.component';
import { RegistroComponent } from './registro/registro.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      InicioComponent,
      RegistroComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [
      AutenticacionService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
