using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;
namespace ProEventos.Application.Contratos
{
    public interface IEventosService
    {
        

  /*AQUI E EM PALESTRANTE É PRECISO TRAZER UM BOOLEANO POIS COMO É UMA RELAÇÃO DE MUITOS PRA MUITOS
   DA UM POUCO MAIS DE TRABALHO PARA TRAZER OS PALESTRANTES QUANDO FOR EVENTOS 
   
   JÁ  DECLARADO A VARIAVEL COM FALSE PARA NÃO SER OBRIGATORIO PASSAR ELA 

   AQUI O PROFESSOR DIZ ESTAR CRIANDO ESSA CAMADA DENTRO DE APPLICATION POIS 
   SE QUISER DELETAR A CAMADA DE PERSISTENCIA PARA USAR OUTRO BANCO DE DADOS QUE NÃO SEJA 
   O ENTITY FRAMEWORK NÃO DE SUPORTE ELE PODE USAR ESSA CAMADA SEM TER QUE FAZER GRANDES 
   ALTERAÇÕES NAS OUTRAS CAMADAS
  */
         Task<Evento>AddEventos(Evento Evento);
          
        Task<Evento>UpdateEvento(int Id,Evento Evento);

        Task<bool>DeleteEvento(int Id);

        Task<Evento[]>GetAllEventosByTemaAsync(string Tema,bool IncluirPalestrantes = false);

       
        Task<Evento[]>GetAllEventosAsync(bool IncluirPalestrantes = false);


        Task<Evento>GetEventoByIdAsync(int Id,bool IncluirPalestrantes = false);


    }
}