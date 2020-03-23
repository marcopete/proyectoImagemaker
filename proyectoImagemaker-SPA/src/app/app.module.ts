import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { InicioComponent } from './inicio/inicio.component';
import { RegistroComponent } from './registro/registro.component';
import { ProveedorDeInterceptorDeErrores } from './_servicios/error.interceptor';

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
      FormsModule,
      BsDropdownModule.forRoot(),
      BrowserAnimationsModule
   ],
   providers: [
      ProveedorDeInterceptorDeErrores
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
