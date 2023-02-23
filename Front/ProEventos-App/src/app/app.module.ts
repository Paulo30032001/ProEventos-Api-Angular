import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import {HttpClientModule} from '@angular/common/http';// IMPORTANDO O MODULO HTTP PARA REQUISIÇÕES;
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; //Importado para o uso do ngx-boostrap e bootstrap
import { NavComponent } from './nav/nav.component';
import  {CollapseModule} from 'ngx-bootstrap/collapse';// PARA O USO DO NAVBAR-COLLAPSE
import {FormsModule} from '@angular/forms' // IMPORTADO PARA O USO DO FORMSMODULE PARA TO-WAY DATA-BIND
// (ASSOCIAÇÃO EM DUAS LINHAS)
@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule, // ARQUIVO DE CONFIGURAÇÃO CENTRAL DO PROJETO CORRESPONDENTE (HTTPCLIENT)
    BrowserAnimationsModule, // ARQUIVO DE CONFIGURAÇÃO CENTRAL DO PROJETO CORRESPONDENTE(NGX-BOOSTRAP)
    CollapseModule.forRoot(), // trazido como um modulo
     FormsModule // ARQUIVO DE CONFIGURAÇÃO CENTRAL DO PROJETO CORRESPONDENTE
  ],
  providers: [],
  bootstrap: [AppComponent] // STARTA O PROJETO UTILIZANDO APPCOMPONENT POIS ISSO ELE PODE SER INSERIDO NA INDEX
})
export class AppModule { }
