import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import {HttpClientModule} from '@angular/common/http';// IMPORTANDO O MODULO HTTP PARA REQUISIÇÕES;
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
@NgModule({
  declarations: [
    AppComponent,
    EventosComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent] // STARTA O PROJETO UTILIZANDO APPCOMPONENT POIS ISSO ELE PODE SER INSERIDO NA INDEX
})
export class AppModule { }
