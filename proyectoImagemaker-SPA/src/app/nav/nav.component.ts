import { Component, OnInit } from '@angular/core';
import { AutenticacionService } from '../_servicios/autenticacion.service';
import { AlertifyService } from '../_servicios/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  modelo: any = {};

  constructor(public servicioAutenticacion: AutenticacionService, private servicioAlertify: AlertifyService, private rutero: Router) { }

  ngOnInit() {
    console.log(this.modelo);
  }

  login() {
    this.servicioAutenticacion.login(this.modelo).subscribe(siguiente => {
      this.servicioAlertify.exito('Logueado exitosamente');
    }, error => {
      this.servicioAlertify.error(error);
    }, () => {
      this.rutero.navigate(['/miembros']);
    });
  }

  logueado() {
    return this.servicioAutenticacion.logueado();
  }

  deslogueado() {
    localStorage.removeItem('token');
    this.servicioAlertify.mensaje('vuelve pronto');
    this.rutero.navigate(['/inicio']);
  }

}
