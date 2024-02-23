import { NgModule } from '@angular/core'; // VEM LA DO CORE(NUCLEO) DO ANGULAR

import { CommonModule } from '@angular/common'; // JÁ VEIO NA PROPRIA CLASSE
import { Routes, RouterModule } from '@angular/router'; // IMPORTANDO O MODULO ROUTERMODULE PARA O USO DAS DIRETIVA ROUTEROUTLET QUE NOS POSSIBILITA INSERIR O CONTEUDO DA ROTA NA PAGINA HTML,ROUTERLINK PARA DIRECIONAR AS ROTAS MAPEADAS PELO OBJETO ROUTES
// IMPORTANDO O OBJETO ROUTES PARA MAPEAR AS ROTAS  DA APLICAÇÃO

// IMPORTANDO OS COMPONENTES ABAIXO PARA SEREM MAPEADOS NA APLICAÇÃO
import { EventosComponent } from './componentes/eventos/eventos/eventos.component';
import { DashboardComponent } from './componentes/dashboard/dashboard.component';
import { PalestrantesComponent } from './componentes/palestrantes/palestrantes.component';
import { ContatosComponent } from './componentes/contatos/contatos.component';
import { PerfilComponent } from './componentes/perfil/perfil.component';
import { EventoListaComponent } from './componentes/eventos/evento-lista/evento-lista.component';
import { EventoDetalheComponent } from './componentes/eventos/evento-detalhe/evento-detalhe.component';

const routes: Routes = [
  // DEFINIMOS O ARRAY QUE CONTEM AS ROTAS
  //CAMINHO(APELIDO COMO VAI SER INSERIDO NO ROUTERLINK(DIRETIVA QUE VAI ENCAMINHAR PARA AS ROTAS MAPEADAS PELO OBJETO ROUTES))

  {path : 'eventos',redirectTo: 'eventos/lista'}, // Redirecionando a rota eventos/lista para quando for chamado só eventos

  {
    path: 'eventos',
    component: EventosComponent, //COMPONENTE PAI
    /*(ESPERA UM ARRAY DE OBJETOS DO TIPO ROUTES QUE ESPERA OBJETOS DO TIPO ROUTE)*/
    children: [
      // TODAS AS ROTAS CRIADAS AQUI SÃO CHAMADAS DENTRO DO COMPONENTE EVENTOS
      { path: 'lista', component: EventoListaComponent }, // A ROTA SERÁ EVENTOS/LISTA
      { path: 'detalhe/:id', component: EventoDetalheComponent }, // :id defini o parametro e seu nome
      { path: 'detalhe', component: EventoDetalheComponent },
    ],
  }, // COMPONENTE É O COMPONENTE QUE VAI SER ENCAMINHADO
  { path: 'palestrantes', component: PalestrantesComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'contatos', component: ContatosComponent },
  { path: 'perfil', component: PerfilComponent },
  //redirecione para o path que já existe
  //pathmath full verifica toda a url que foi digitada
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' }, // QUANDO NÃO PASSAR NADA NA URL,
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }, // QUANDO PASSAR UMA URL QUE NÃO EXISTE NA APLICAÇÃO
  //EXEMPLO http://localhost:4200/DNKJANDJKANJKANDJKAA
  // TEM QUE SER INSERIDO POR ULTIMO SE NÃO ELE NÃO REDIRECIONA OS COMPONENTES DAQUI PRA BAIXO
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes), // TRAZIDO COMO UM MODULO (ARQUIVO CENTRAL DE CONFIGURAÇÃO DO PROJETO/PACOTE @ANGULAR/ROUTER)
    // FOR ROOT (FAZ COM O COMPONENTE FAÇA A INJEÇÃO DO COMPONENTE USANDO O DECORATOR INJECTABLE)
    // E PASSA PARA ESSE SERVIÇO QUE FICA DISPONIVEL EM TODA APLICAÇÃO PARA REDIRECIONAR AS ROTAS MAPEADAS EM ROUTES
    // IMPORTANDO O MODULO PARA O USO DAS DIRETIVAS PROVENIENTES DO MOUDULO DE ROUTERMODULE
  ],
  exports: [RouterModule], // NESSARIO EXPORTAR TAMBÉM PARA QUE SEJA PASSADO PARA APP.MODULE.TS(ARQUIVO CENTRAL DE CONFIGURAÇÃO DO NOSSO PORJETO) POR MEIO DE APP-ROUTING.MODULE.TS
})
export class AppRoutingModule {}
