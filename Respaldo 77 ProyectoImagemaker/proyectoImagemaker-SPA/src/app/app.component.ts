import { Component, OnInit } from '@angular/core';
import { AutenticacionService } from './_servicios/autenticacion.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  apoyoJwt = new JwtHelperService();

  constructor(private servicioAutenticacion: AutenticacionService) {}

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.servicioAutenticacion.tokenDecodificado = this.apoyoJwt.decodeToken(token);
    }
  }
}
