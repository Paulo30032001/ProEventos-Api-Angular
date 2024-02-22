import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppComponent } from "./app.component";
import { EventosComponent } from "./componentes/eventos/eventos/eventos.component";
import {HttpClientModule} from "@angular/common/http";// IMPORTANDO O MODULO HTTP PARA REQUISIÇÕES;
import { BrowserAnimationsModule } from "@angular/platform-browser/animations"; //Importado para o uso do ngx-boostrap e bootstrap
import { NavComponent } from "./shared/nav/nav.component";
import  {CollapseModule} from "ngx-bootstrap/collapse";// IMPORTANTO O MODULO PARA O USO DO COLLAPSEMODULE PARA O USO DA PROPERTIEBINDING DE COLLAPSE (É UMA PROPRIEDADE DE ASSOIACAÇÃO) PARA A DIRETIVA COLLAPSEDIRETIVE QUE POSSIBILITA MUDAR O ESTADO DA BARRA DE NAVEGAÇÃO E ABRIR UM MENU QUANDO ESTIVER COMO FALSE
import {FormsModule} from "@angular/forms"; // IMPORTADO PARA O USO DO FORMSMODULE PARA TO-WAY DATA-BIND
// (ASSOCIAÇÃO EM DUAS LINHAS)
import { EventoService } from "./services/Evento.service";// Importando para injeção de dependencia
import {DateTimeFormatPipe}  from "./helpers/DateTimeFormat.pipe";
import {BsDropdownModule} from "ngx-bootstrap/dropdown"; // IMPORTANDO MODULO PARA O USO DAS DIRETIVAS DE DROPDOWN
import {TooltipModule} from "ngx-bootstrap/tooltip";// IMPORTANDO MODULO PARA O USO DAS PROPERTIESBINDING DE TOOLTIPMODULE
import { ModalModule } from "ngx-bootstrap/modal" ; // IMPORTANDO MODULO PARA O USO DO SERVICE DE MODAL QUE NOS POSSIBILITA PEGAR A REFERENCIA(NA VIEW(TEMPLEATE))  DA DIRETIVA ng-templeate QUE VEM LA DO CORE DO ANGULAR ATRAVÉS DA CLASSE TemplateRef QUE LOCALIZA A DIRETIVA EM QUESTÃO NA VIEW(TEMPLEATE DO COMPONENTE) (ABERTURA DE CAIXAS DE DIALOGO)
import {ToastrModule} from "ngx-toastr"; // IMPORTANDO O MODULO PARA O USO DO SERVICE DE NGX-TOASTR
                                         // PARA TER OS ALERTAS(FORMATADOS) OU SEJA
                                         // COMO SE FOSSEM NOTIFICAÇÕES COM BARRAS DE PROGRESSO

import {NgxSpinnerModule} from "ngx-spinner";
import { TituloComponent } from "./shared/titulo/titulo.component";//IMPORTANDO O MODULO PARA O USO DO SERVICE DE NGX-SPINNER(NgxSpinnerService)
import { PalestrantesComponent } from "./componentes/palestrantes/palestrantes.component";
import { ContatosComponent } from './componentes/contatos/contatos.component';
import { DashboardComponent } from './componentes/dashboard/dashboard.component';
import { PerfilComponent } from './componentes/perfil/perfil.component';
                                             // VAI NOS POSSIBILITAR USAR ANIMAÇÕES QUE VÃO APARENTAR
                                            // ESTAR CARREGANDO DURANTE UMA AÇÃO
                                             //E A DIRETIVA (RECURSO DO ANGULAR PARA MANIPULAR O HTML) DE NGX-SPINNER


import { AppRoutingModule } from "./app-routing.module";// IMPORTANDO  O MODULE PARA O USO DE APP-ROUTING-MODULE
import { EventoListaComponent } from './componentes/eventos/evento-lista/evento-lista.component';
import { EventoDetalheComponent } from './componentes/eventos/evento-detalhe/evento-detalhe.component';

@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    NavComponent,
    DateTimeFormatPipe,
    TituloComponent, // DECLARADO O NOSSO PRIMEIRO PIPE(FILTRO)
    PalestrantesComponent,
    ContatosComponent,
    DashboardComponent,
    PerfilComponent,
    EventoListaComponent,
    EventoDetalheComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule, // ARQUIVO DE CONFIGURAÇÃO CENTRAL DO PROJETO CORRESPONDENTE (HTTPCLIENT)
    BrowserAnimationsModule, // ARQUIVO DE CONFIGURAÇÃO CENTRAL DO PROJETO CORRESPONDENTE(NGX-BOOSTRAP)
    CollapseModule.forRoot(), //  TRAZIDO COMO UM MODULO (ARQUIVO DE CONFIGURAÇÃO DO PROJETO CORRESPONDENTE)
    //VAI NOS POSSIBILITAR USAR NA VIEW(TEMPLEATE) AS PROPERTIEBINDINGS DE COLLAPSE (É UMA PROPRIEDADE DE ASSOIACAÇÃO) PARA A DIRETIVA COLLAPSEDIRETIVE QUE POSSIBILITA MUDAR O ESTADO DA BARRA DE NAVEGAÇÃO E ABRIR UM MENU QUANDO ESTIVER COMO FALSE
     FormsModule, // ARQUIVO DE CONFIGURAÇÃO CENTRAL DO PROJETO CORRESPONDENTE
     // VAI NOS POSSIBILITAR APLICAR O TWO-WAY DATA BINDING(ASSOCIAÇÃO EM DOIS CAMINHOS)
     BsDropdownModule.forRoot(), //  TRAZIDO COMO UM MODULO (ARQUIVO DE CONFIGURAÇÃO DO PROJETO CORRESPONDENTE),
     //VAI NOS POSSIBILIDAR USAR AS DIRETIVAS(RECURSOS DO ANGULAR PARA MANIPULAR O HTML)
     //PROVENIENTES DO MODULO DE DROPDWON)
     TooltipModule.forRoot(), //  TRAZIDO COMO UM MODULO (ARQUIVO DE CONFIGURAÇÃO DO PROJETO CORRESPONDENTE),
     //VAI NOS POSSIBILIDAR USAR AS PROPERTIESBINDING(PROPRIEDADES DE ASSOSIAÇÃO) DE TOOLTIPMODULE
    //PROVENIENTES DO MODULO DE TOOLTIP)
     ModalModule.forRoot(),  //  TRAZIDO COMO UM MODULO (ARQUIVO DE CONFIGURAÇÃO DO PROJETO CORRESPONDENTE) VAI NOS POSSIBILITAR USAR O MODALSERVICE PARA EXIBIR UM CONTEUDO ATRAVÉS DA DIRETIVA ng-templeate (ATRAVÉS DA CLASSE TEMPLEATEREF QUE VEM LA DO CORE DO ANGULAR) E RETORNAR A REFERENCIA(NA VIEW TEMPLEATE DA DIRETIVA)   E PASSALA PARA UMA VARIAVEL DO TIPO BsModalRef QUE COM ESSA REFERENCIA ARMAZENADA PODERA FECHAR ESSE MODAL(JANELA DE DIALOGO)
     ToastrModule.forRoot({
      closeButton : true, // ATIVAR BOTÃO DE FECHAR NO ALERTA
      timeOut : 3000, // equivale a 3 segundos (TEMPO DE DURAÇÃO DO ALERTA)
       positionClass : "toast-bottom-right", // POSIÇÃO DO ALERTA
       progressBar : true // BARRA DE PROGRESSO
       // progressAnimation É POSSIVEL CONFIGURAR A DIREÇÃO QUE BARRA CORRE PRA DIREITA OU ESQUERDA
    }),
    NgxSpinnerModule,
    AppRoutingModule // ARQUIVO DE CONFIGURAÇÃO PARA NÃO DEIXAR O APP.MODULE.TS MUITO VERBOSO EXPORTANDO(TRAZENDO ATRAVÉS DELE O ROUTERMODULE(ARQUIVO CENTRAL DE CONFIGURAÇÃO DE @ANGULAR ROUTER QUE NOS PERMITE HABILITAR A NAVEGAÇÃO NO ANGULAR))
    ],
  providers: [EventoService], // 3 forma fica disponivel para todos os components declarados aqui em APPMODULE
  bootstrap: [AppComponent] // STARTA O PROJETO UTILIZANDO APPCOMPONENT POIS ISSO ELE PODE SER INSERIDO NA INDEX
})
export class AppModule { }
