import {Routes} from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { ListaMiembrosComponent } from './lista-miembros/lista-miembros.component';
import { MensajesComponent } from './mensajes/mensajes.component';
import { ListasComponent } from './listas/listas.component';
import { AuthGuard } from './_guardias/auth.guard';

export const rutasApp: Routes = [
    { path: 'inicio', component: InicioComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'miembros', component: ListaMiembrosComponent, canActivate: [AuthGuard] },
            { path: 'mensajes', component: MensajesComponent},
            { path: 'listas', component: ListasComponent},
        ]
    },
    { path: '**', redirectTo: 'inicio', pathMatch: 'full'}
];
