import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AutenticacionService } from '../_servicios/autenticacion.service';
import { AlertifyService } from '../_servicios/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private servicioAutenticacion: AutenticacionService, private rutero: Router, private servicioAlertify: AlertifyService) {}

  canActivate(): boolean {
    if (this.servicioAutenticacion.logueado()) {
      return true;
    }

    this.servicioAlertify.error('NO PASARAS');
    this.rutero.navigate(['/inicio']);
    return false;
  }
}
