using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventosPersistence
    {
        

  /*AQUI E EM PALESTRANTE É PRECISO TRAZER UM BOOLEANO POIS COMO É UMA RELAÇÃO DE MUITOS PRA MUITOS
   DA UM POUCO MAIS DE TRABALHO PARA TRAZER OS PALESTRANTES QUANDO FOR EVENTOS 
   
   E PRA TRAZER OS PALESTRANTES QUANDO FOR EVENTOS 

  */

        //EVENTOS
        Task<Evento[]>GetAllEventosByTemaAsync(string Tema,bool IncluirPalestrantes);

       
        Task<Evento[]>GetAllEventosAsync(bool IncluirPalestrantes);


        Task<Evento>GetEventoByIdAsync(int Id,bool IncluirPalestrantes);

        Task<Evento>GetEventoByIdAsNoTrackingAsync(int Id,bool IncluirPalestrantes);
        // INCLUIDO OBJETO NÃO RASTRAVEL
       
    }
}