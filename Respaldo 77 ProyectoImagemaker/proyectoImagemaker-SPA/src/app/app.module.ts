import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { InicioComponent } from './inicio/inicio.component';
import { RegistroComponent } from './registro/registro.component';
import { ProveedorDeInterceptorDeErrores } from './_servicios/error.interceptor';
import { ListaMiembrosComponent } from './lista-miembros/lista-miembros.component';
import { ListasComponent } from './listas/listas.component';
import { MensajesComponent } from './mensajes/mensajes.component';
import { rutasApp } from './routes';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      InicioComponent,
      RegistroComponent,
      ListaMiembrosComponent,
      ListasComponent,
      MensajesComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      BrowserAnimationsModule,
      RouterModule.forRoot(rutasApp)
   ],
   providers: [
      ProveedorDeInterceptorDeErrores
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
