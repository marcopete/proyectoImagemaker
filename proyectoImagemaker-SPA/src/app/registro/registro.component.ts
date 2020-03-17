import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AutenticacionService } from '../_servicios/autenticacion.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {
  @Input() valoresDeInicio: any;
  @Output() cancelarRegistro = new EventEmitter();
  modelo: any = {};

  constructor(private servicioAutenticacion: AutenticacionService) { }

  ngOnInit() {
  }

  registrar() {
    this.servicioAutenticacion.registrar(this.modelo).subscribe(() => {
      console.log('registro exitoso');
    }, error => {
      console.log(error);
    });
  }

  cancelar() {
    this.cancelarRegistro.emit(false);
    console.log('cancelado');
  }

}
