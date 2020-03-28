import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {
  modoRegistro = false;


  constructor(private http: HttpClient) { }

  ngOnInit() {

  }

  arrancaRegistro() {
    this.modoRegistro = !this.modoRegistro;
  }

  // obtenerValores() {
  //   this.http.get('http://localhost:5000/api/values').subscribe(respuesta => {
  //     this.valores = respuesta;
  //     console.log(respuesta);
  //   }, error => {
  //     console.log(error);
  //   });
  // }

  modoCancelarRegistro(modoRegistro: boolean) {
    this.modoRegistro = modoRegistro;
  }

}
