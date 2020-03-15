import { Component, OnInit } from '@angular/core';
import { AutenticacionService } from '../_servicios/autenticacion.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  modelo: any = {};

  constructor(private servicioAutenticacion: AutenticacionService) { }

  ngOnInit() {
    console.log(this.modelo);
  }

  login() {
    this.servicioAutenticacion.login(this.modelo).subscribe(siguiente => {
      console.log('Logueado exitosamente');
    }, error => {
      console.log('Mal logueado');
    });
  }

  logueado() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  deslogueado() {
    localStorage.removeItem('token');
    console.log('vuelve pronto');
  }

}
