using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Contextos;
namespace ProEventos.Persistence
{
    public class EventosPersistence : IEventosPersistence
    {
        private readonly ProEventosContext context;
        public EventosPersistence(ProEventosContext context)
        {
            this.context = context;
            //this.context.ChangeTracker.QueryTrackingBehavior= QueryTrackingBehavior.NoTracking; 
            //TORNAR O RETORNO DE TUDO QUE USAR O CONTEXT AQUI NÃO RASTREAVEL  
        }

            /*AQUI E EM PALESTRANTE É PRECISO TRAZER UM BOOLEANO POIS COMO É UMA RELAÇÃO DE MUITOS PRA MUITOS
  DA UM POUCO MAIS DE TRABALHO PARA TRAZER OS PALESTRANTES QUANDO FOR EVENTOS 
    E PRA TRAZER OS PALESTRANTES QUANDO FOR EVENTOS 

 */

     #region  Eventos
        //EVENTOS
        /*TODOS OS IncluirPalestrantes JÁ VEM COM FALSE COMO PADRÃO NÃO SENDO NECESSARIO PASSAR*/
        public async Task<Evento[]> GetAllEventosByTemaAsync(string Tema, bool IncluirPalestrantes = false)
        {
             var query = context.Eventos.AsQueryable();
            query= query.Where(x => x.Tema.Contains(Tema));
             
            if (IncluirPalestrantes)
            {
                // AQUI ELE CONSEGUE ACESSAR DENTRO DE PALESTRANTE EVENTO O PALESTRANTE
                // NÃO É POSSIVEL ACESSAR LOGO DENTRO DO PRIMEIRO INCLUDE POIS É UMA LISTA
              query= query.Include(x => x.PalestrantesEventos).ThenInclude(x=>x.Palestrante);
            }

            return await query
            .Include(x=>x.Lotes)
             .Include(x=>x.RedesSociais)
             .OrderBy(x=>x.Id)
             .ToArrayAsync();

        }


        public async Task<Evento[]> GetAllEventosAsync(bool IncluirPalestrantes = false)
        {
            var query = context.Eventos.AsQueryable();
             
            if (IncluirPalestrantes)
            {
                // AQUI ELE CONSEGUE ACESSAR DENTRO DE PALESTRANTE EVENTO O PALESTRANTE
                // NÃO É POSSIVEL ACESSAR LOGO DENTRO DO PRIMEIRO INCLUDE POIS É UMA LISTA
              query= query.Include(x => x.PalestrantesEventos).ThenInclude(x=>x.Palestrante);
            }

            return await query
            .Include(x=>x.Lotes)
             .Include(x=>x.RedesSociais)
              .OrderBy(x=>x.Id)
             .ToArrayAsync();


        }


        public async Task<Evento> GetEventoByIdAsync(int Id, bool IncluirPalestrantes = false)
        {

            var query = context.Eventos.AsQueryable();
          
            if (IncluirPalestrantes)
            {
                // AQUI ELE CONSEGUE ACESSAR DENTRO DE PALESTRANTE EVENTO O PALESTRANTE
                // NÃO É POSSIVEL ACESSAR LOGO DENTRO DO PRIMEIRO INCLUDE POIS É UMA LISTA
              query= query.Include(x => x.PalestrantesEventos).ThenInclude(x=>x.Palestrante);
            }

            return await query
            .OrderBy(x=>x.Id==Id)
            .Where(x => x.Id == Id)
            .Include(x=>x.Lotes)
             .Include(x=>x.RedesSociais)
             .FirstOrDefaultAsync();

        }


         public async Task<Evento> GetEventoByIdAsNoTrackingAsync(int Id, bool IncluirPalestrantes = false)
        {

            var query = context.Eventos.AsQueryable();
          
            if (IncluirPalestrantes)
            {
                // AQUI ELE CONSEGUE ACESSAR DENTRO DE PALESTRANTE EVENTO O PALESTRANTE
                // NÃO É POSSIVEL ACESSAR LOGO DENTRO DO PRIMEIRO INCLUDE POIS É UMA LISTA
              query= query.Include(x => x.PalestrantesEventos).ThenInclude(x=>x.Palestrante);
            }

            return await query
            .OrderBy(x=>x.Id==Id)
            .Where(x => x.Id == Id)
            .Include(x=>x.Lotes)
             .Include(x=>x.RedesSociais)
             .AsNoTracking().FirstOrDefaultAsync();

        }
      #endregion

    }
}